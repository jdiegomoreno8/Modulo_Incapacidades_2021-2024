using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace NegocioParametros.General
{
   public class SexoNegocio : ISexoNegocio
    {
        readonly IAccesoDatosReadOnly sexoRepositorio;

        public SexoNegocio(IAccesoDatosReadOnly sexoRepositorioIn)
        {
            sexoRepositorio = sexoRepositorioIn;
        }
		public IList<Sexo> Consultar_Todos_Sexo() =>
			//return sexoRepositorio.Consultar_Sexo();
			(IList<Sexo>)sexoRepositorio.Consultar_Sexo();
	}
}
