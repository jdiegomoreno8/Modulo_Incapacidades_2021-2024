using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteServicio pacientesServicio;
        public PacienteController(IPacienteServicio pacientesServicioIn)
        {
            pacientesServicio = pacientesServicioIn;
        }

        // GET: api/<PacientesController>
        [HttpGet("{idTipoDocumento}/{numeroDocumento}/{numeroIncapacidad}")]
        public Paciente Get(string idTipoDocumento, string numeroDocumento, string numeroIncapacidad)
        {
            var paciente = pacientesServicio.ConsultarPaciente(idTipoDocumento, numeroDocumento, numeroIncapacidad);
            return paciente;
        }


        // POST api/<PacientesController>
        [HttpPost]
        public IActionResult Post([FromBody] Paciente pacientes)
        {
            var pacientesNueva = pacientesServicio.AdicionarPaciente(pacientes);
            return Ok(pacientesNueva);
        }
    }
}
