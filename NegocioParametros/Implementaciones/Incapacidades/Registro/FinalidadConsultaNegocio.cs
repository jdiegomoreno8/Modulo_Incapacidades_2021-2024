using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
    public class FinalidadConsultaNegocio
    {
        readonly IAccesoDatosReadOnly finalidadConsultaRepositorio;

		public FinalidadConsultaNegocio(IAccesoDatosReadOnly finalidadConsultaRepositorioIn)
		{
			finalidadConsultaRepositorio = finalidadConsultaRepositorioIn;
		}
		public IList<FinalidadConsulta> Consultar_Todos_Finalidad_Consulta()
		{
			//return finalidadConsultaRepositorio.Consultar_Finalidad_Consulta();
			return (IList<FinalidadConsulta>) finalidadConsultaRepositorio.Consultar_Finalidad_Consulta();
		}


	}
}
