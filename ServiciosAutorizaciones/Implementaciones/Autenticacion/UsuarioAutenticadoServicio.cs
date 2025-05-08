using LibreriasAutorizaciones.Modelos;
using LibreriasAutorizaciones.Modelos.DTO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NegocioAutorizaciones.Autenticacion;
using Newtonsoft.Json.Linq;
using ServiciosAutorizaciones.Implementaciones.Autenticacion;
using System;
using System.Collections.Generic;

namespace ServiciosAutorizaciones.Autenticacion
{
	public class UsuarioAutenticadoServicio : IUsuarioAutenticadoServicio
    {
		private readonly IAutenticarNegocio autenticarNegocio;
        //private readonly TokenManagement tokenManagement;
        private readonly IConfiguration configuration;
        private readonly IUsuarioNegocio usuarioNegocio;
        private readonly ITokenHandlerCustom tokenHandlerCustom;

        public UsuarioAutenticadoServicio(IAutenticarNegocio autenticarNegocioIn/*, IOptions<TokenManagement> tokenManagement*/, IConfiguration configuration, 
            IUsuarioNegocio usuarioNegocio, ITokenHandlerCustom tokenHandlerCustom)
        {
            this.autenticarNegocio = autenticarNegocioIn;
            //this.tokenManagement = tokenManagement.Value;
            this.configuration = configuration;
            this.usuarioNegocio = usuarioNegocio;
            this.tokenHandlerCustom = tokenHandlerCustom;
        }

        public bool UsuarioValido(Int64 idHercules, Login login, Usuario usuario, out string Token, out string refreshToken) 
		{
            Token = string.Empty;
            refreshToken = string.Empty;
            if (!AutorizarToken())
                return false;

            //var claims = new[]
            //{
            //    new Claim(ClaimTypes.Name,usuario.nombreUsuario)
            //};
            //var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenManagement.Secret));
            //var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            //var jwtToken = new JwtSecurityToken(tokenManagement.Issuer, tokenManagement.Audience, claims, expires: DateTime.Now.AddMinutes(tokenManagement.AccessExpiration), signingCredentials: credentials);

            //Token = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            if (autenticarNegocio.VerificarUsuario(idHercules, login, usuario)){
                //TokenHandlerCustom._configuration = configuration;
                tokenHandlerCustom.CreateAccessToken(usuario.nombreUsuario, out Token);// : new UnauthorizedResult());
                refreshToken = tokenHandlerCustom.GenerateRefreshToken();
                return true;
            }
            else {
                return false;
            }
		}

		public bool ActualizarPerfilUsuario(Perfil perfil)
		{
			return autenticarNegocio.VerificarUsuarioEntidad(perfil);
		}

		public bool AutorizarToken()
		{ return true; }

        public string ActualizarDatosToken(Usuario usuario)
        {
            return usuarioNegocio.ActualizarUsuarioDatosToken(usuario);
        }

        public IList<Usuario> ConsultarUsuarioPorNombreUsuario(string nombreUsuario)
        {
            return usuarioNegocio.ConsultarUsuarioPorNombreUsuario(nombreUsuario);
        }

    }
}
