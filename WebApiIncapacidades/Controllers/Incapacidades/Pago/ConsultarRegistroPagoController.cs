using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades.Interfaces;

namespace WebApiIncapacidades.Controllers.Incapacidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultarRegistroPagoController : ControllerBase
    {
        private readonly IConsultarRegistroPagoServicio consultarRegistroPagoServicio;
   
        public ConsultarRegistroPagoController(IConsultarRegistroPagoServicio consultarRegistroPagoServicioIn)
        {
            consultarRegistroPagoServicio = consultarRegistroPagoServicioIn;
        }

        [HttpPost("ConsultarRegistroPago")]
        public string PostConsultarRegistroPago([FromBody] ConsultarRegistroPago consultarRegistroPago)
        {
            var registroPago = consultarRegistroPagoServicio.ObtenerConsultaRegistroPago(consultarRegistroPago);
            return registroPago;
        }
    }
}
