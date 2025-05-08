using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades.Implementaciones;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using WebApiIncapacidades.Modelos.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers.Incapacidades.Registrar
{
    [Route("api/Incapacidad/[controller]")]
    [ApiController]
    public class PerdidaCapacidadLaboralController : ControllerBase
    {
        private readonly IPerdidaCapacidadLaboralServicio perdidaCapacidadLaboralServicio;
        public PerdidaCapacidadLaboralController(IPerdidaCapacidadLaboralServicio perdidaCapacidadLaboralServicio)
        {
            this.perdidaCapacidadLaboralServicio = perdidaCapacidadLaboralServicio;
        }

        // GET: api/Incapacidad/PerdidaCapacidadLaboralController
        [HttpGet ("{id_concepto_registro}")]
        public IEnumerable<PerdidaCapacidadLaboral> Get(Int64 id_concepto_registro)
        {
            var perdidaCapacidadLaboral = perdidaCapacidadLaboralServicio.Consultar_PerdidaCapacidadLaboral(id_concepto_registro);
            return perdidaCapacidadLaboral;
        }


        [HttpPost]
        public string Post([FromBody] PerdidaCapacidadLaboral pcl)
        {
            var resultado = perdidaCapacidadLaboralServicio.AdicionarPerdidaCapacidadLaboral(pcl).resultado;
            return resultado;
        }
    }
}
