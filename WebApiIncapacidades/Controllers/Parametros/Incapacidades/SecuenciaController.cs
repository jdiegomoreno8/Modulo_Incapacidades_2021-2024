using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using WebApiIncapacidades.Implementaciones;

namespace WebApiIncapacidades.Controllers
{
    [Route("api/Incapacidad/[controller]")]
    [ApiController]
    public class SecuenciaController : ControllerBase
    {
        private readonly IIncapacidadServicio incapacidadServicio;


        public SecuenciaController(IIncapacidadServicio incapacidadServicio)
        {
            this.incapacidadServicio= incapacidadServicio;
        }

        [HttpGet("{codigo}")]
        public IActionResult Get(string codigo)
        {
            return Ok(incapacidadServicio.ObtenerSecuenciaPorCodigo(codigo));      
        }

    }
}
