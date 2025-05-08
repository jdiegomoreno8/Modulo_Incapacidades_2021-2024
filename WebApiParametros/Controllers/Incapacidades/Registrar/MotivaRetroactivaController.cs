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
    public class MotivaRetroactivaController : ControllerBase
    {
        private readonly IMotivaRetroactivaServicio motivaRetroactivaServicio;
        private IMemoryCache _memoryCache;
        private readonly string motivaRetroactivaCollectionKey = "motivaRetroactivaCollectionKey";
        public MotivaRetroactivaController(IMotivaRetroactivaServicio motivaRetroactivaServicioIn, IMemoryCache memoryCache)
        {
            motivaRetroactivaServicio = motivaRetroactivaServicioIn;
            _memoryCache = memoryCache;

        }
        // GET: api/<MotivaRetroactivaController>
        [HttpGet]
        public IEnumerable<MotivaRetroactiva> Get()
        {
            //var ListaMotivaRetroactiva = motivaRetroactivaServicio.Consultar_Motiva_Retroactiva();
            //return ListaMotivaRetroactiva;
            if (_memoryCache.TryGetValue(motivaRetroactivaCollectionKey, out IEnumerable<MotivaRetroactiva> motivaRetroactivaCollection))
            {
                return motivaRetroactivaCollection;
            }
            motivaRetroactivaCollection = motivaRetroactivaServicio.Consultar_Motiva_Retroactiva();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(motivaRetroactivaCollectionKey, motivaRetroactivaCollection);

            return motivaRetroactivaCollection;
        }

       
    }
}
