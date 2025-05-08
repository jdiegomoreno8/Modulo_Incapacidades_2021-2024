using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades.Interfaces
{
   public interface ITipoPagoNegocio
    {
        IList<TipoPago> Consultar_Todos_Tipo_Pago();
    }
}
