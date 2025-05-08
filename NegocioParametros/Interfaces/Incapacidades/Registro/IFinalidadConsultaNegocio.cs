using System.Collections.Generic;
using LibreriasParametros.Modelos.Incapacidades;

namespace NegocioParametros.Incapacidades
{
    public interface IFinalidadConsultaNegocio
    {
       // readonly IAccesoDatosReadOnly finalidadConsultaRepositorio;

        //  public FinalidadConsultaNegocio(IAccesoDatosReadOnly finalidadConsultaRepositorioIn)
        //{
        //finalidadConsultaRepositorio = finalidadConsultaRepositorioIn;
        //}
        //public IList<FinalidadConsulta> Consultar_Todos_Finalidad_Consulta()
        //{
        //	return finalidadConsultaRepositorio.Consultar_Finalidad_Consulta();
        //}

        IList<FinalidadConsulta> Consultar_Todos_Finalidad_Consulta();

    }
}
