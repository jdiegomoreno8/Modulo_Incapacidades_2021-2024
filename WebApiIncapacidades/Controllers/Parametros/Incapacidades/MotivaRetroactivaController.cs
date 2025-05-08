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
