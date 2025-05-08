using System;

namespace LibreriasAutorizaciones.Modelos
{
	public class PerfilComple
	{
		public int  idEntidad { get; set; }
		public int idRol { get; set; }
		public Int64 idUsuarioEntidadRol { get; set; }
		public string codDepto { get; set; }
		public string codMunicipio { get; set; }
	}

	
}
