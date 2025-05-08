using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
   public interface ITipoPagoServicio
    {
        public IEnumerable<TipoPago> Consultar_Tipo_Pago();
    }
}
