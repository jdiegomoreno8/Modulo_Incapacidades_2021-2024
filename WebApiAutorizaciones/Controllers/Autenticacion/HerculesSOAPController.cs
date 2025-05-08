using Microsoft.AspNetCore.Mvc;
using System;
using HerculesSOAP;
using LibreriasAutorizaciones.Modelos;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using ServiciosAutorizaciones.Autenticacion;
using Newtonsoft.Json.Linq;
using ServiciosAutorizaciones.Implementaciones.Autenticacion;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace WebApiIncapacidades.Controllers
{
	[ApiController]
	public class HerculesSOAPController : Controller
	{
		private bool usuarioValidado;
		private customMembershipUser2 datosUsuario;
		private List<Perfil> rolUsuario;

		private readonly IAutorizacionTokenServicio _autenticacion;
		private readonly IUsuarioAutenticadoServicio _usuarioAutenticadoServicio;
        private readonly ITokenHandlerCustom tokenHandlerCustom;
        private readonly IConfiguration configuration;


        public HerculesSOAPController(IAutorizacionTokenServicio objetoAutenticacion, IUsuarioAutenticadoServicio objetoUsuarioAutenticado, 
			ITokenHandlerCustom tokenHandlerCustom, IConfiguration configuration)
		{
			this._autenticacion = objetoAutenticacion;
			this._usuarioAutenticadoServicio = objetoUsuarioAutenticado;
			this.tokenHandlerCustom = tokenHandlerCustom;
			this.configuration = configuration;

        }


		[Route("api/[controller]/Autenticar/{Aplicacion}/{NombreUsuario}/{Contrasena}/{Ip}")]
		[HttpGet]
		public ActionResult AutenticarUsuario(string Aplicacion, string NombreUsuario, string Contrasena, string Ip)
		{
			Login datosLogueo = new Login();
			datosLogueo.Aplicacion = Aplicacion;
			datosLogueo.NombreUsuario = NombreUsuario;
			datosLogueo.Contrasena = Contrasena;
			datosLogueo.Ip = Ip;

			if (!ModelState.IsValid)
			{
				return Json(BadRequest("Invalid Request"));
			}

			string token;
			if (_autenticacion.UsuarioAutenticado(datosLogueo, out token))
			{
				usuarioValidado = Convert.ToBoolean(ValidarUsuario(datosLogueo).ValidarUsuario2Result);

				if (usuarioValidado == true)
				{
					datosUsuario = ObtenerDatosUsuario(datosLogueo.NombreUsuario).ObtenerUsuarioPorNombreUsuario2Result;
					rolUsuario = TraerRolUsuario(datosLogueo.Aplicacion, datosLogueo.NombreUsuario);
					DatosUsuarioUnificado u = UnificarDatosUsuario(datosLogueo, datosUsuario, rolUsuario, usuarioValidado);

                    u.datosUsuario.access_token = (u.datosUsuario != null) ? token  : string.Empty;
					string j = JsonConvert.SerializeObject(u);
					return Content(j.ToString(), "application/json", Encoding.UTF8);
				}

				else
				{
					DatosUsuarioUnificado du = new DatosUsuarioUnificado();
					du.loginUsuario = new Login();
					du.datosUsuario = new Usuario();
					return Json(du);
				}
			}

			else
			{ return Json(BadRequest("Invalid Request")); }


		}

		[Route("api/[controller]/Autenticar2")]
		[HttpPost]
		//public JsonResult AutenticarUsuario2(Login datosLogueo)
		public ActionResult AutenticarUsuario2(Login datosLogueo)
		{

			usuarioValidado = Convert.ToBoolean(ValidarUsuario(datosLogueo).ValidarUsuario2Result);
			datosUsuario = ObtenerDatosUsuario(datosLogueo.NombreUsuario).ObtenerUsuarioPorNombreUsuario2Result;
			rolUsuario = TraerRolUsuario(datosLogueo.Aplicacion, datosLogueo.NombreUsuario);

			if (usuarioValidado == true && rolUsuario.Count >0)
			{
				bool usuarioValidado=false;
				bool perfilActualizado = false; 
				
				//return Json(UnificarDatosUsuario(datosLogueo, datosUsuario, rolUsuario, usuarioValidado));
				DatosUsuarioUnificado u = UnificarDatosUsuario(datosLogueo, datosUsuario, rolUsuario, usuarioValidado);

                string token;
                usuarioValidado = _usuarioAutenticadoServicio.UsuarioValido(u.datosRol[0].idUsuario2, u.loginUsuario, u.datosUsuario, out token, out string refreshToken);

                u.datosUsuario.access_token = (u.datosUsuario != null) ? token : string.Empty;
                u.datosUsuario.refresh_token = (u.datosUsuario != null) ? refreshToken : string.Empty;
				u.datosUsuario.date_expiration = DateTime.Now.AddMinutes(int.Parse(configuration["JWT:RefreshTokenExpireTime"]));

                _usuarioAutenticadoServicio.ActualizarDatosToken(u.datosUsuario);

                int s = u.datosRol.Count;
				int t = 0;

				while (t < s)
				{
					perfilActualizado = _usuarioAutenticadoServicio.ActualizarPerfilUsuario(u.datosRol[t]);
					t = t + 1;
				}

				if (usuarioValidado == true && perfilActualizado == true)
				{
                    string j = JsonConvert.SerializeObject(u);
					return Content(j.ToString(), "application/json", Encoding.UTF8);
				}
				else {
					DatosUsuarioUnificado du = new DatosUsuarioUnificado();
					du.loginUsuario = new Login();
					du.datosUsuario = new Usuario();
                    //return Json(du);
                    string j = JsonConvert.SerializeObject(du);
                    return Content(j.ToString(), "application/json", Encoding.UTF8);
                }

			}

			else
			{
				DatosUsuarioUnificado du = new DatosUsuarioUnificado();
				du.loginUsuario = new Login();
				du.datosUsuario = new Usuario();
                string j = JsonConvert.SerializeObject(du);
                return Content(j.ToString(), "application/json", Encoding.UTF8);
                //return Json(du);
			}
		}

        [HttpPost]
        [Route("api/[controller]/RefreshToken")]
        public IActionResult RefreshToken(TokenApiModel tokenApiModel)
        {
            if (tokenApiModel is null)
                return BadRequest("Invalid client request");

            string accessToken = tokenApiModel.AccessToken;	
            string refreshToken = tokenApiModel.RefreshToken;

            var principal = tokenHandlerCustom.GetPrincipalFromExpiredToken(accessToken);
            var username = principal.Identity.Name; //this is mapped to the Name claim by default
            
			var user = _usuarioAutenticadoServicio.ConsultarUsuarioPorNombreUsuario(username).FirstOrDefault();
            
            if (user is null || user.refresh_token != refreshToken)
                return StatusCode(401, new  { code_error_1 = "481", b = 1 }	);
				//return BadRequest("Invalid client request");

            tokenHandlerCustom.CreateAccessToken(user.nombre_usuario, out string newAccessToken);
			
            user.access_token = newAccessToken;
            user.nombreUsuario = user.nombre_usuario;

            string newRefreshToken;
            if (user.date_expiration <= DateTime.Now)
			{
                newRefreshToken = tokenHandlerCustom.GenerateRefreshToken();
                user.refresh_token = newRefreshToken;
				user.date_expiration = DateTime.Now.AddMinutes(int.Parse(configuration["JWT:RefreshTokenExpireTime"]));
			}
			else
			{
				newRefreshToken = refreshToken;
            }
			
            _usuarioAutenticadoServicio.ActualizarDatosToken(user);

			
            return Ok(new AuthenticatedResponse()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            });
        }


        private static List<Perfil> TraerRolUsuario(string aplicacion, string usuario)
		{
			var a = ObtenerRolUsuario(aplicacion, usuario).BuscarUsuario2EntidadRolResult;

			EntidadRol er = new EntidadRol();
			DataSet s = er.ToDataSet(a);

			List<Perfil> pf = new List<Perfil>();
			Perfil usuarioUnificado = new Perfil();

			foreach (DataRow r in s.Tables[0].Rows)
			{
				usuarioUnificado = new Perfil();
				usuarioUnificado.codigoEntidad = ConvertFromDBVal<string>(r[3]);
				usuarioUnificado.descripcionRol = ConvertFromDBVal<string>(r[7]);
				usuarioUnificado.idRol = ConvertFromDBVal<int>(r[5]);
				usuarioUnificado.idUsuario2 = ConvertFromDBVal<int>(r[0]);
				usuarioUnificado.nit = ConvertFromDBVal<string>(r[12]);
				usuarioUnificado.nombreEntidad = ConvertFromDBVal<string>(r[4]);
				usuarioUnificado.nombreRol = ConvertFromDBVal<string>(r[6]);

				pf.Add(usuarioUnificado);
			}

			return (pf);
		}


		private static ValidarUsuario2Response ValidarUsuario(Login datosLogueo)
		{
			SecurityProvider2SoapClient cliente = new SecurityProvider2SoapClient(SecurityProvider2SoapClient.EndpointConfiguration.SecurityProvider2Soap);
			ValidarUsuario2Request validarUsuario = new ValidarUsuario2Request { applicationName = datosLogueo.Aplicacion, Login = datosLogueo.NombreUsuario, password = datosLogueo.Contrasena, ip = datosLogueo.Ip };
			ValidarUsuario2Response respuesta = cliente.ValidarUsuario2Async(validarUsuario).Result;

			return respuesta;
		}

		private static ObtenerUsuarioPorNombreUsuario2Response ObtenerDatosUsuario(string usuario)
		{
			SecurityProvider2SoapClient cliente = new SecurityProvider2SoapClient(SecurityProvider2SoapClient.EndpointConfiguration.SecurityProvider2Soap);
			ObtenerUsuarioPorNombreUsuario2Request datosUsuario = new ObtenerUsuarioPorNombreUsuario2Request { username = usuario };
			ObtenerUsuarioPorNombreUsuario2Response respuesta = cliente.ObtenerUsuarioPorNombreUsuario2Async(datosUsuario).Result;

			return respuesta;
		}

		private static BuscarUsuario2EntidadRolResponse ObtenerRolUsuario(string aplicacion, string usuario)
		{
			SecurityProvider2SoapClient cliente = new SecurityProvider2SoapClient(SecurityProvider2SoapClient.EndpointConfiguration.SecurityProvider2Soap);
			BuscarUsuario2EntidadRolRequest rolUsuario = new BuscarUsuario2EntidadRolRequest { Aplicacion = aplicacion, Usuario = usuario };
			BuscarUsuario2EntidadRolResponse respuesta = cliente.BuscarUsuario2EntidadRolAsync(rolUsuario).Result;

			return respuesta;
		}


		public static DatosUsuarioUnificado UnificarDatosUsuario(Login datosLogueo, customMembershipUser2 datosUsuarioRetor, List<Perfil> datosRolRetor, bool usuarioValidado)
		{

			DatosUsuarioUnificado usuarioUnificado = new DatosUsuarioUnificado();
			usuarioUnificado.loginUsuario = datosLogueo;
			usuarioUnificado.datosUsuario = new Usuario();
			usuarioUnificado.datosUsuario.usuarioValidado = usuarioValidado;
			usuarioUnificado.datosUsuario.nombreUsuario = datosUsuarioRetor.Login;
			usuarioUnificado.datosUsuario.tipoDocumento = datosUsuarioRetor.TipoDocumento;
			usuarioUnificado.datosUsuario.numeroDocumento = datosUsuarioRetor.NumeroDocumento;
			usuarioUnificado.datosUsuario.primerNombre = datosUsuarioRetor.PrimerNombre;
			usuarioUnificado.datosUsuario.segundoNombre = datosUsuarioRetor.SegundoNombre;
			usuarioUnificado.datosUsuario.primerApellido = datosUsuarioRetor.PrimerApellido;
			usuarioUnificado.datosUsuario.segundoApellido = datosUsuarioRetor.SegundoApellido;
			usuarioUnificado.datosUsuario.registroProfesional = datosUsuarioRetor.Profesion;
			usuarioUnificado.datosUsuario.profesion = datosUsuarioRetor.RegistroProfesional;
			usuarioUnificado.datosUsuario.email = datosUsuarioRetor.Email;
			usuarioUnificado.datosUsuario.programaUsuario = datosUsuarioRetor.ProgramaUsuario;
			usuarioUnificado.datosUsuario.bloqueado = datosUsuarioRetor.Bloqueado;
			usuarioUnificado.datosUsuario.deshabilitado = datosUsuarioRetor.Deshabilitado;
			usuarioUnificado.datosUsuario.erroresLogin = datosUsuarioRetor.ErroresLogin;
			usuarioUnificado.datosUsuario.fechaCreacion = datosUsuarioRetor.FechaCreacion;
			usuarioUnificado.datosUsuario.fechaUltActualizacion = datosUsuarioRetor.FechaUltActualizacion;
			usuarioUnificado.datosUsuario.requiereCambioClave = datosUsuarioRetor.RequiereCambioClave;
			usuarioUnificado.datosRol = datosRolRetor;

			return usuarioUnificado;

		}

		public static T ConvertFromDBVal<T>(object obj)
		{
			if (obj == null || obj == DBNull.Value)
			{
				return default(T); // returns the default value for the type
			}
			else
			{
				return (T)obj;
			}
		}

	}

    public class AuthenticatedResponse
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }

    public class TokenApiModel
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }

    public class EntidadRol
	{
		public string CodigoEntidad { get; set; }
		public string NombreEntidad { get; set; }
		public bool UsuarioHabilitado { get; set; }

		public DataSet ToDataSet(ArrayOfXElement arrayOfXElement)
		{
			var strSchema = arrayOfXElement.Nodes[0].ToString();
			var strData = arrayOfXElement.Nodes[1].ToString();
			var strXml = "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n\t<DataSet>";
			strXml += strSchema + strData;
			strXml += "</DataSet>";

			DataSet ds = new DataSet("TestDataSet");
			ds.ReadXml(new MemoryStream(Encoding.UTF8.GetBytes(strXml)));

			return ds;
		}
	}

}
