using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using WebApiIncapacidades.Implementaciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers.Parametros
{
    [Route("api/[controller]")]
    [ApiController]
    public class CausalGlosaController : ControllerBase
    {
        private readonly ICausalGlosaServicio causalGlosaServicio;
        private IMemoryCache _memoryCache;
        private readonly string causalGlosaCollectionKey = "causalGlosaCollectionKey";
        public CausalGlosaController(ICausalGlosaServicio causalGlosaServicioIn, IMemoryCache memoryCache)
        {
            causalGlosaServicio = causalGlosaServicioIn;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public IEnumerable<CausalGlosa> Get()
        {
            //var ListaCausalGlosa = causalGlosaServicio.Consultar_Causal_Glosa();
            //return ListaCausalGlosa;
            if (_memoryCache.TryGetValue(causalGlosaCollectionKey, out IEnumerable<CausalGlosa> causalGlosaCollection))
            {
                return causalGlosaCollection;
            }
            causalGlosaCollection = causalGlosaServicio.Consultar_Causal_Glosa();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(causalGlosaCollectionKey, causalGlosaCollection);

            return causalGlosaCollection;
        }
    }
}
