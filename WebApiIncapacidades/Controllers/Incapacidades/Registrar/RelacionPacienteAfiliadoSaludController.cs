using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibreriasIncapacidades.Modelos;
using ServiciosIncapacidades.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers.Incapacidades.Registrar
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelacionPacienteAfiliadoSaludController : ControllerBase
    {
        private readonly IRelacionPacienteAfiliacionSaludServicio relacionPacienteAfiliacionSaludServicio;
        public RelacionPacienteAfiliadoSaludController(IRelacionPacienteAfiliacionSaludServicio relacionPacienteAfiliadoSaludServicioIn)
        {
            relacionPacienteAfiliacionSaludServicio = relacionPacienteAfiliadoSaludServicioIn;
        }

        // GET: api/<RelacionPacienteAfiliadoSaludController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RelacionPacienteAfiliadoSaludController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RelacionPacienteAfiliadoSaludController>
        public IActionResult Post([FromBody] RelacionPacienteAfiliacionSalud relacionPacienteAfiliacionSalud)
        {
            var resultado = relacionPacienteAfiliacionSaludServicio.AdicionarRelacionPacienteAfiliacionSalud(relacionPacienteAfiliacionSalud);
            return Ok(resultado);
        }

        // PUT api/<RelacionPacienteAfiliadoSaludController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RelacionPacienteAfiliadoSaludController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
