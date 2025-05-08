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
    public class TranstornoMentalController : ControllerBase
    {
        private readonly ITranstornoMentalServicio transtornoMentalServicio;
        private IMemoryCache _memoryCache;
        private readonly string transtornoMentalCollectionKey = "transtornoMentalCollectionKey";
        public TranstornoMentalController(ITranstornoMentalServicio TrasntornoMentalServicioIn, IMemoryCache memoryCache)
        {
            transtornoMentalServicio = TrasntornoMentalServicioIn;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public IEnumerable<TranstornoMental> Get()
        {
            //var ListaTranstornoMental = transtornoMentalServicio.Consultar_Trasntorno_Mental();
            //return ListaTranstornoMental;
            if (_memoryCache.TryGetValue(transtornoMentalCollectionKey, out IEnumerable<TranstornoMental> transtornoMentalCollection))
            {
                return transtornoMentalCollection;
            }
            transtornoMentalCollection = transtornoMentalServicio.Consultar_Trasntorno_Mental();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(transtornoMentalCollectionKey, transtornoMentalCollection);

            return transtornoMentalCollection;
        }

    }
}
