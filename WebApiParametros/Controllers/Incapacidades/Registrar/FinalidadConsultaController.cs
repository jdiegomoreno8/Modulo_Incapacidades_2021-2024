using LibreriasParametros.Modelos.Incapacidades;
using Microsoft.AspNetCore.Mvc;
using ServiciosParametros.Incapacidades;
using System.Collections.Generic;


namespace WebApiParametros.Controllers.Incapacidades
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
