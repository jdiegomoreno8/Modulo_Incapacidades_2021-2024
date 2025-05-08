using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
  public interface ICausaAtencionServicio
    {
        public IEnumerable<CausaAtencion> Consultar_Causa_Motivo_Atencion();
    }
}
