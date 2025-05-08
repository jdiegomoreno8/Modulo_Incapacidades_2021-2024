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
    public class CausalDiasController : ControllerBase
    {
        private readonly ICausalDiasServicio causalDiasServicio;
        private IMemoryCache _memoryCache;
        private readonly string causalDiasCollectionKey = "causalDiasCollectionKey";
        public CausalDiasController(ICausalDiasServicio cuasalDiasServicioIn, IMemoryCache memoryCache)
        {
            causalDiasServicio = cuasalDiasServicioIn;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public IEnumerable<CausalDias> Get()
        {
            //var lista = causalDiasServicio.Consultar_Causal_Dias();
            //return lista;

            if (_memoryCache.TryGetValue(causalDiasCollectionKey, out IEnumerable<CausalDias> causalDiasCollection))
            {
                return causalDiasCollection;
            }
            causalDiasCollection = causalDiasServicio.Consultar_Causal_Dias();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(causalDiasCollectionKey, causalDiasCollection);

            return causalDiasCollection;
        }
    }
}
