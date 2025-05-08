using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers.Incapacidades.Registrar
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrarPagoController : ControllerBase
    {
        private readonly IRegistrarPagoServicio registrarPagoServicio;
        public RegistrarPagoController(IRegistrarPagoServicio registrarPagoServicioIn)
        {
            registrarPagoServicio = registrarPagoServicioIn;
        }
        [HttpPost]
        public string Post([FromBody] RegistrarPago registrarPago)
        {
            var resultado = registrarPagoServicio.AdicionarRegistrarPago(registrarPago);
            return resultado;
        }

        [HttpPost("ConsultarPagos")]
        public IList<RegistrarPago> ConsultarPagos([FromBody] RegistrarPago registrarPago)
        {
            var resultado = registrarPagoServicio.ConsultarRegistrosPago(registrarPago);
            return resultado;
        }
    }

}
