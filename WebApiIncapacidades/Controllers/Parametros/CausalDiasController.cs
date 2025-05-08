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
