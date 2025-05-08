using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
using LibreriasIncapacidades.Modelos;
using WebApiIncapacidades.Modelos.DTO;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;
using ServiciosIncapacidades.Interfaces;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

//namespace WebApiIncapacidades.Controllers
namespace WebApiIncapacidades.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaMedicoController : ControllerBase
    {
        private readonly IConsultaMedicoServicio consultaMedicoServicio;

        public ConsultaMedicoController(IConsultaMedicoServicio consultaMedicoServicioIn)
        {
            consultaMedicoServicio = consultaMedicoServicioIn;
        }

        //GET: api/<ConsultaMaestroPriorizadoServicioController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpPost("ConsultaMedicoRethus")]
        public IActionResult PostConsultaMedicoRethus([FromBody] Medico medico)
        {
            Medico datosConsultados = consultaMedicoServicio.ConsultarMedicoRethus(medico);

            if (datosConsultados != null && !string.IsNullOrWhiteSpace(datosConsultados.numero_documento))
            {
                return Ok(datosConsultados);
            }
            else
            {
                throw new KeyNotFoundException("Medico no encontrado");
            }
        }

    }
}
