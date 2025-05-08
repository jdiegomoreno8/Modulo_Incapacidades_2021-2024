using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;

namespace ServiciosParametros.Incapacidades
{
  public class CausaAnulacionServicio : ICausaAnulacionServicio
    {
        private readonly ICausaAnulacionNegocio CausaAnulacionNegocio;
        public CausaAnulacionServicio(ICausaAnulacionNegocio CausaAnulacionNegocioIn)
        {
            CausaAnulacionNegocio = CausaAnulacionNegocioIn;
        }


        public IEnumerable<CausaAnulacion> Consultar_Causa_Anulacion()
        {
            var ListaCausaAnulacion = CausaAnulacionNegocio.Consultar_Todos_Causa_Anulacion();
            return ListaCausaAnulacion;
        }
    }

}

