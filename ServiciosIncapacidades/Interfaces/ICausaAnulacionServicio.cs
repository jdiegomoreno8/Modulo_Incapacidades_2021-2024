using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
  public interface ICausaAnulacionServicio
    {
        public IEnumerable<CausaAnulacion> Consultar_Causa_Anulacion();
    }
}
