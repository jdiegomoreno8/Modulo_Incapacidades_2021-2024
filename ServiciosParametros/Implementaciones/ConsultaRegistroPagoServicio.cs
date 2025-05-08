using LibreriasParametros.Modelos;
using NegocioParametros;

namespace ServiciosParametros
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
