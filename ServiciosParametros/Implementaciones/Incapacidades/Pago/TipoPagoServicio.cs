using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;

namespace ServiciosParametros.Incapacidades
{
   public class TipoPagoServicio : ITipoPagoServicio
    {
        private readonly ITipoPagoNegocio tipoPagoNegocio;
        public TipoPagoServicio(ITipoPagoNegocio tipoPagoNegocioIn)
        {
            tipoPagoNegocio = tipoPagoNegocioIn;
        }

        public IEnumerable<TipoPago> Consultar_Tipo_Pago()
        {
            var ListaTipoPago = tipoPagoNegocio.Consultar_Todos_Tipo_Pago();
            return ListaTipoPago;
        }
    }
}
