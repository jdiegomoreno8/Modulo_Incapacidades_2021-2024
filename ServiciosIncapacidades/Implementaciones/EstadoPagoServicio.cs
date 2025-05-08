using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
{
    public class EstadoPagoServicio : IEstadoPagoServicio
    {
        private readonly IEstadoPagoNegocio estadoPagoNegocio;
        public EstadoPagoServicio(IEstadoPagoNegocio estadoPagoNegocioIn)
        {
            estadoPagoNegocio = estadoPagoNegocioIn;
        }

        public IEnumerable<EstadoPago> Consultar_Estado_Pago()
        {
            var ListaEstadoPago = estadoPagoNegocio.Consultar_Todos_Estado_Pago();
            return ListaEstadoPago;
        }
    }
}