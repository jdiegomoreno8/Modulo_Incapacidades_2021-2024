using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
   public interface ITipoPagoServicio
    {
        public IEnumerable<TipoPago> Consultar_Tipo_Pago();
    }
}
