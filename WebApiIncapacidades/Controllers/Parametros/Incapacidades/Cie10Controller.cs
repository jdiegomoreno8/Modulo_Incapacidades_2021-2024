using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using WebApiIncapacidades.Implementaciones;

namespace WebApiIncapacidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cie10Controller : ControllerBase
    {
        private readonly ICie10Servicio cie10Servicio;
        private IMemoryCache _memoryCache;
        private readonly string Cie10CollectionKey = "Cie10CollectionKey";

        public Cie10Controller(ICie10Servicio cie10ServicioIn, IMemoryCache memoryCache)
        {
            cie10Servicio = cie10ServicioIn;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IEnumerable<Cie10> Get()
        {
            //var ListaRegistros = cie10Servicio.ObtenerCie10();
            //return ListaRegistros;
            if (_memoryCache.TryGetValue(Cie10CollectionKey, out IEnumerable<Cie10> Cie10Collection))
            {
                return Cie10Collection;
            }
            Cie10Collection = cie10Servicio.ObtenerCie10();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(Cie10CollectionKey, Cie10Collection);

            return Cie10Collection;
        }

        [HttpGet("{value}")]
        public IEnumerable<Cie10> Get(string value)
        {
            var ListaRegistros = cie10Servicio.ObtenerCie10(value);
            return ListaRegistros;
        }
    }
}
