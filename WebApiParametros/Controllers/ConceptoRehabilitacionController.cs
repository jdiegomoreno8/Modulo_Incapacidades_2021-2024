using Microsoft.AspNetCore.Mvc;
using ServiciosParametros;
using LibreriasParametros.Modelos;


namespace WebApiParametros.Controllers.Incapacidades
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConceptoRehabilitacionController : Controller
    {
        private readonly IConceptoRehabilitacionServicio conceptoRehabilitacionServicio;
        public ConceptoRehabilitacionController(IConceptoRehabilitacionServicio conceptoRehabilitacionServicioIn)
        {
            conceptoRehabilitacionServicio = conceptoRehabilitacionServicioIn;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("ConsultaIncapacidadCR")]
        public IActionResult PostConsultaIncapacidadCR([FromBody] Paciente paciente)
        {
            var listaIncapacidades = conceptoRehabilitacionServicio.ConsultarIncapacidad(paciente);
            return Ok(listaIncapacidades);
        }

        [HttpPost("GuardarConceptoRehabilitacion")]
        public IActionResult Post([FromBody] RegistroConceptoRehabilitacion concepto)
        {
            var conceptoRehabilitacionResult = conceptoRehabilitacionServicio.RegistrarConcepto(concepto);
            return Ok(conceptoRehabilitacionResult);
        }

        [HttpPost("ConsultarCRPorPaciente")]
        public IActionResult PostConsultarCRPorPaciente([FromBody] Paciente paciente)
        {
            var conceptoRehabilitacionResult = conceptoRehabilitacionServicio.ConsultarPorPaciente(paciente);
            return Ok(conceptoRehabilitacionResult);
        }


    }
}
