using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
  public interface ICausaAnulacionServicio
    {
        public IEnumerable<CausaAnulacion> Consultar_Causa_Anulacion();
    }
}
