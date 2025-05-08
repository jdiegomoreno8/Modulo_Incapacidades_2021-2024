using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
using LibreriasIncapacidades.Modelos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnulacionController : ControllerBase
    {
        private readonly IAnulacionServicio anulacionServicio;
        public AnulacionController(IAnulacionServicio anulacionServicioIn)
        {
            anulacionServicio = anulacionServicioIn;
        }


        // POST api/<IncapacidadesController>
        [HttpPost]
        public IActionResult Post([FromBody] IncapacidadAnulada incapacidadAnulada)
        {
            var Incacacidad = anulacionServicio.AnularIncapacidad(incapacidadAnulada);
            return Ok(Incacacidad);
        }      
    }
}
