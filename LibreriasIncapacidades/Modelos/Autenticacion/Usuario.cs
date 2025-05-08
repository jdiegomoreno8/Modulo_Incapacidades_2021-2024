using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
	public class Usuario
	{
		public bool usuarioValidado { get; set; }
		public string nombreUsuario { get; set; } 
		public string tipoDocumento { get; set; }
		public string numeroDocumento { get; set; }
		public string primerNombre { get; set; }
		public string segundoNombre { get; set; }
		public string primerApellido { get; set; }
		public string segundoApellido { get; set; }
		public string registroProfesional { get; set; }
		public string profesion { get; set; }
		public string email { get; set; }
		public string tipoUsuario { get; set; }
		public string programaUsuario { get; set; }
		public bool bloqueado { get; set; }
		public bool deshabilitado { get; set; }
		public int erroresLogin { get; set; }
		public DateTime fechaCreacion { get; set; }
		public DateTime fechaUltActualizacion { get; set; }
		public bool requiereCambioClave { get; set; }
	}
}
