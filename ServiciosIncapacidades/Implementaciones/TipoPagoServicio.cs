using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
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
