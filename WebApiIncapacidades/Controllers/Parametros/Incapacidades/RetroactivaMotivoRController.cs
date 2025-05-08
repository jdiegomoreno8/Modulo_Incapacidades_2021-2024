using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using WebApiIncapacidades.Implementaciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RetroactivaMotivoRController : ControllerBase
    {
        private readonly IRetroactivaMotivoRServicio retroactivaMotivoRServicio;
        private IMemoryCache _memoryCache;
        private readonly string retroactivaMotivoRCollectionKey = "retroactivaMotivoRCollectionKey";
        public RetroactivaMotivoRController(IRetroactivaMotivoRServicio retroactivaMotivoRServicioIn, IMemoryCache memoryCache)
        {
            retroactivaMotivoRServicio = retroactivaMotivoRServicioIn;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public IEnumerable<MotivaRetroactiva> Get()
        {
            //var ListaRetroactivaMotivoR = retroactivaMotivoRServicio.ObtenerRetroactivaMotivoR();
            //return ListaRetroactivaMotivoR;
            if (_memoryCache.TryGetValue(retroactivaMotivoRCollectionKey, out IEnumerable<MotivaRetroactiva> retroactivaMotivoRCollection))
            {
                return retroactivaMotivoRCollection;
            }
            retroactivaMotivoRCollection = retroactivaMotivoRServicio.ObtenerRetroactivaMotivoR();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(retroactivaMotivoRCollectionKey, retroactivaMotivoRCollection);

            return retroactivaMotivoRCollection;
        }

      
    }
}
