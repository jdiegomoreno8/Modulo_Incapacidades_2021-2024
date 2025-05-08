using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
{
   public class ConsultaRegistroPagoServicio : IConsultarRegistroPagoServicio
    {
        private readonly IConsultarRegistroPagoNegocio registroPagoNegocio;
        public ConsultaRegistroPagoServicio(IConsultarRegistroPagoNegocio registroPagoNegocioIn)
        {
            registroPagoNegocio = registroPagoNegocioIn;
        }
        public string ObtenerConsultaRegistroPago(ConsultarRegistroPago consultarRegistroPago)
        {
            var consultaRegistroPago = registroPagoNegocio.ObtenerTodosConsultaRegistroPago(consultarRegistroPago);
            return consultaRegistroPago;
        }

    }
}
