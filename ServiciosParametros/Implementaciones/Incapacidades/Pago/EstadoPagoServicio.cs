using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;

namespace ServiciosParametros.Incapacidades
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