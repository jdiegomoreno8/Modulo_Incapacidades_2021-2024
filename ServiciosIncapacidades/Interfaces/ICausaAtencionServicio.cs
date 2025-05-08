using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
  public interface ICausaAtencionServicio
    {
        public IEnumerable<CausaAtencion> Consultar_Causa_Motivo_Atencion();
    }
}
