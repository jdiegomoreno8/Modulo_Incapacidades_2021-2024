using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
    public class CausaAnulacionNegocio : ICausaAnulacionNegocio
    {
        readonly IAccesoDatosReadOnly causaAnulacionRepositorio;

        public CausaAnulacionNegocio(IAccesoDatosReadOnly causaAnulacionRepositorioIn)
        {
            causaAnulacionRepositorio = causaAnulacionRepositorioIn;
        }
        public IList<CausaAnulacion> Consultar_Todos_Causa_Anulacion()
        {
            //return causaAnulacionRepositorio.Consultar_Causa_Anulacion();
            return (IList<CausaAnulacion>)causaAnulacionRepositorio.Consultar_Causa_Anulacion();
        }
    }
}
