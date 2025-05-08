using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LibreriasIncapacidades.Modelos;
using ServiciosIncapacidades.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers.Incapacidades.Registrar
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelacionPacienteAportanteController : ControllerBase
    {
        private readonly IRelacionPacienteAportanteServicio relacionPacienteAportanteServicio;
        public RelacionPacienteAportanteController(IRelacionPacienteAportanteServicio relacionPacienteAportanteServicioIn)
        {
            relacionPacienteAportanteServicio = relacionPacienteAportanteServicioIn;
        }

        [HttpGet("{id_incapacidad}")]
        public IEnumerable<RelacionPacienteAportante> Get(string id_incapacidad)
        {
            var relacionPacienteAportante = relacionPacienteAportanteServicio.Consultar_Relacion_Paciente_Aportante(id_incapacidad);
            return relacionPacienteAportante;
        }
    }
}