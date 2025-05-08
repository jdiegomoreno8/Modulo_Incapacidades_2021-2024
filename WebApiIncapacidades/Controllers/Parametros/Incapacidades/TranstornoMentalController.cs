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
