using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace LibreriasIncapacidades.Modelos
{
	public class Login
    {
        [Required]
        public string Aplicacion { get; set; }

        [Required]
        //[JsonProperty("username")]
        public string NombreUsuario { get; set; }

        [Required]
        public string Contrasena { get; set; }

        [Required]
        public string Ip { get; set; }

    }
}

