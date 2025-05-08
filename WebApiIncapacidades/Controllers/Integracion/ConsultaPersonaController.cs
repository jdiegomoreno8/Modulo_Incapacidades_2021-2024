using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.Integracion;
using System.Threading;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaPersonaController : ControllerBase
    {
        private readonly IConsultaPersonaServicio consultaPersonaServicio;

        public ConsultaPersonaController(IConsultaPersonaServicio consultaPersonaServicioIn)
        {
            consultaPersonaServicio = consultaPersonaServicioIn;
        }

        //GET: api/<ConsultaMaestroPriorizadoServicioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[HttpPost]
        //public IActionResult PostConsultaPorPaciente([FromBody] Paciente paciente)
        //{
        //    Paciente datosConsultados = consultaMaestroPriorizadoServicio.ConsultarPacienteMaestroPriorizado(paciente);

        //    if (!string.IsNullOrWhiteSpace(datosConsultados.numero_documento)) {
        //        return Ok(datosConsultados);
        //    }
        //    else {
        //        throw new KeyNotFoundException("Persona no encontrada");
        //    }
        //}

        [HttpPost]
        public IActionResult PostConsultaPorPaciente([FromBody] Paciente paciente)
        {
            Paciente datosConsultados = consultaPersonaServicio.Consultar(paciente);

            if (datosConsultados != null && !string.IsNullOrWhiteSpace(datosConsultados.numero_documento))
            {
                return Ok(datosConsultados);
            }
            else
            {
                throw new KeyNotFoundException("Persona no encontrada");
            }
        }


    }
}
