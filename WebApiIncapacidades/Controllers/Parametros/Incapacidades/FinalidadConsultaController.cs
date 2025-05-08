using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebApiIncapacidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalidadConsultaController : ControllerBase
    {
        private readonly IFinalidadConsultaServicio finalidadConsultaServicio;
        public FinalidadConsultaController(IFinalidadConsultaServicio finalidadconsultaServicioIn)
        {
            finalidadConsultaServicio = finalidadconsultaServicioIn;
        }
        [HttpGet]

        public IEnumerable<FinalidadConsulta> Get()
        {
            var ListaFinalidadConsulta = finalidadConsultaServicio.Consultar_Finalidad_Consulta();
            return ListaFinalidadConsulta;
        }



    }
}
