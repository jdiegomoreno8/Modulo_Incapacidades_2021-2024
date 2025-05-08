using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CausaAnulacionController : ControllerBase
    {
        private readonly ICausaAnulacionServicio causaAnulacionServicio;
        public CausaAnulacionController(ICausaAnulacionServicio causaAnulacionServicioIn)
        {
            causaAnulacionServicio = causaAnulacionServicioIn;
        }
        [HttpGet]
        public IEnumerable<CausaAnulacion> Get()
        {
            var ListaCausaAnulacion = causaAnulacionServicio.Consultar_Causa_Anulacion();
            return ListaCausaAnulacion;
        }

    
    }
}
