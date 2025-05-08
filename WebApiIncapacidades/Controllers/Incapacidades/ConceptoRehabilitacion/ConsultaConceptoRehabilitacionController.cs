using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades.Implementaciones;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers.Incapacidades.ConceptoRehabilitacion
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaConceptoRehabilitacionController : ControllerBase


    {
        private readonly IConsultaConceptoRehabilitacionServicio conceptoRehabilitacionServicio;
        public ConsultaConceptoRehabilitacionController(IConsultaConceptoRehabilitacionServicio conceptoRehabilitacionServicioIn)
        {
            conceptoRehabilitacionServicio = conceptoRehabilitacionServicioIn;
        }


        [HttpPost("ConsultarListaCR")]
        public IActionResult PostConsultarListaCR([FromBody] Paciente pacienteCR)
        {
            var consultarConceptosRehabilitacion = conceptoRehabilitacionServicio.Consultar_ListasConceptosRehabilitacion(pacienteCR);
           return Ok(consultarConceptosRehabilitacion);
        }


    }
}
