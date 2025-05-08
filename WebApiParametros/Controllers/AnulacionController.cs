using LibreriasParametros.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosParametros;

namespace WebApiParametros.Controllers.Incapacidades
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
