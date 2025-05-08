using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
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
