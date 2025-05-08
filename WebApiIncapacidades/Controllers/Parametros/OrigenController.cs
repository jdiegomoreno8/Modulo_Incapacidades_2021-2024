using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using WebApiIncapacidades.Implementaciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrigenController : ControllerBase
    {
        private readonly IOrigenServicio origenServicio;
        private IMemoryCache _memoryCache;
        private readonly string origenCollectionKey = "origenCollectionKey";
        public OrigenController(IOrigenServicio origenServicioIn, IMemoryCache memoryCache)
        {
           origenServicio = origenServicioIn;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public IEnumerable<Origen> Get()
        {
            //var ListaOrigen = origenServicio.Consultar_Origen();
            //return ListaOrigen;
            if (_memoryCache.TryGetValue(origenCollectionKey, out IEnumerable<Origen> origenCollection))
            {
                return origenCollection;
            }
            origenCollection = origenServicio.Consultar_Origen();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(origenCollectionKey, origenCollection);

            return origenCollection;
        }

      
    }
}
