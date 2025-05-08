using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
using LibreriasIncapacidades.Modelos;
using WebApiIncapacidades.Modelos.DTO;
using System.Collections.Generic;
using Microsoft.Extensions.Hosting;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IncapacidadController : ControllerBase
    {
        private readonly IIncapacidadServicio incapacidadServicio;
        private readonly IGenerarIncapacidadPdfServicio generarIncapacidadPdfServicio;

        public IHostingEnvironment HostingEnvironment { get; }

        public IncapacidadController(IIncapacidadServicio incapacidadServicioIn, IGenerarIncapacidadPdfServicio generarIncapacidadPdfServicioIn, IHostingEnvironment env)
        {
            incapacidadServicio = incapacidadServicioIn;
            generarIncapacidadPdfServicio = generarIncapacidadPdfServicioIn;
            HostingEnvironment = env;
        }

        [HttpGet("{numeroIncapacidad}/{tipoDocumento}/{numeroDocumento}")]
        public IActionResult Get(string numeroIncapacidad, string tipoDocumento, string numeroDocumento)
        {
            var Incacacidad = incapacidadServicio.ObtenerIncapacidad(numeroIncapacidad, tipoDocumento, numeroDocumento);
            return Ok(Incacacidad);
        }

        [HttpGet("{idIncapacidad}")]
        public IActionResult Get(string idIncapacidad)
        {
            var CamposCausaAnulacion = incapacidadServicio.ObtenerCamposAnulacionIncapacidad(idIncapacidad);
            return Ok(CamposCausaAnulacion);

        }

        [HttpPost("ConsultaPorPaciente")]
        public IActionResult PostConsultaPorPaciente([FromBody] Incapacidad incapacidad)
        {
            var listaIncapacidades = incapacidadServicio.ConsultarIncapacidad(incapacidad);
            return Ok(listaIncapacidades);
        }

        // POST api/<IncapacidadesController>
        //[HttpPost]
        //public IActionResult Post([FromBody] Incapacidad incapacidad)
        //{
        //    var incapacidadNueva = incapacidadServicio.AdicionarIncapacidad(incapacidad);            
        //    return Ok(incapacidadNueva);
        //}

        [HttpPost]
        public IActionResult Post([FromBody] DatosRegistroIncapacidadDTO data)
        {
            var incapacidadNueva = incapacidadServicio.AdicionarIncapacidadDatosAdicionales(data);
            return Ok(incapacidadNueva);
        }

       [HttpPost("GenerarIncapacidadPdf")]
        public IActionResult GenerarIncapacidadPdf([FromBody] Incapacidad incapacidad)
        {
            Incapacidad incapacidadConsultada = incapacidadServicio.ObtenerIncapacidad(incapacidad.id_incapacidad.ToString(), incapacidad.tipo_documento_pac, incapacidad.numero_documento_pac);
            if (incapacidadConsultada != null)
            {
                var archivo = generarIncapacidadPdfServicio.GenerarPDF(incapacidadConsultada, HostingEnvironment.ContentRootPath);
                return File(archivo, "application/pdf");
            } else
            {
                throw new KeyNotFoundException("Persona no encontrada");
            }
            

        }

    }
}
