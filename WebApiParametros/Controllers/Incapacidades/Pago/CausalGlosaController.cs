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
