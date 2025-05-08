using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

using Newtonsoft.Json;
using System.Net;
using System.Collections.Generic;
using ServiciosAutorizaciones.Autenticacion;
using LibreriasAutorizaciones.Modelos.DTO;
using LibreriasAutorizaciones.Modelos;

namespace WebApiIncapacidades.Controllers
{
	[ApiController]
	public class AutenticacionController : Controller
	{

		private readonly IAutorizacionTokenServicio _autenticacion;

		public AutenticacionController(IAutorizacionTokenServicio objetoAutenticacion)
		{
			this._autenticacion = objetoAutenticacion;
		}

        [Route("api/[controller]/ValidarRecaptcha")]
        [HttpPost]
        public ActionResult ValidarRecaptcha(RecaptchaRequest datosRecaptcha)
        {
            string token = datosRecaptcha.token;
            string llaveSegura = datosRecaptcha.llaveSegura;

            var client = new WebClient();
            var jsonResult = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", llaveSegura, token));
            return Ok(JsonConvert.DeserializeObject<ReCaptchaResponse>(jsonResult.ToString()));
        }


        [AllowAnonymous]
        [HttpPost, Route("requestToken")]

        public ActionResult RequestToken([FromBody] Login datosLogueo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid Request");
            }

            string token;
            if (_autenticacion.UsuarioAutenticado(datosLogueo, out token))
            {
                return Ok(token);
            }
            else
            { return BadRequest("Invalid Request"); }
            

        }

    }

    public class ReCaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}
