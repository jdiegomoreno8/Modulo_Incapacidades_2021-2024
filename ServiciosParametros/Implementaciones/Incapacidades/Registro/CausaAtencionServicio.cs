using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;

namespace ServiciosParametros.Incapacidades
{
  public class CausaAtencionServicio : ICausaAtencionServicio
    {
        private readonly ICausaAtencionNegocio causaAtencionNegocio;
        public CausaAtencionServicio(ICausaAtencionNegocio causaAtencionNegocioIn)
        {
            causaAtencionNegocio = causaAtencionNegocioIn;
        }
        public IEnumerable<CausaAtencion> Consultar_Causa_Motivo_Atencion()
        {
            var ListaCausaAtencion = causaAtencionNegocio.Consultar_Todos_Causa_Motivo_Atencion();
            return ListaCausaAtencion;
        }

    }
}
