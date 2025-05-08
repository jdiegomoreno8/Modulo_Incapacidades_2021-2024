using LibreriasParametros.Modelos.Incapacidades;
using Microsoft.AspNetCore.Mvc;
using ServiciosParametros.Incapacidades;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using WebApiParametros.Utility;

namespace WebApiParametros.Controllers.Incapacidades
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
