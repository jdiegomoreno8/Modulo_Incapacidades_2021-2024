using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers.Integracion
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteNoEncontradoController : ControllerBase
    {
        private readonly IPacienteNoEncontradoServicio pacienteNoEncontradoServicio;

        public PacienteNoEncontradoController(IPacienteNoEncontradoServicio pacienteNoEncontradoServicioIn)
        {
            pacienteNoEncontradoServicio = pacienteNoEncontradoServicioIn;
        }

        // GET: api/<PacienteNoEncontradoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<PacienteNoEncontradoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PacienteNoEncontradoController>
        public IActionResult Post([FromBody] PacienteNoEncontrado pacienteNoEncontrado)
        {
            var incapacidadNueva = pacienteNoEncontradoServicio.AdicionarPacienteNoEncontrado(pacienteNoEncontrado);
            return Ok(incapacidadNueva);
        }

        //// PUT api/<PacienteNoEncontradoController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<PacienteNoEncontradoController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
