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

namespace WebApiIncapacidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MunicipiosController : ControllerBase
    {
        private readonly IMunicipiosServicio municipiosServicio;
        private IMemoryCache _memoryCache;
        private readonly string municipiosCollectionKey = "municipiosCollectionKey";
        public MunicipiosController(IMunicipiosServicio municipiosServicioIn, IMemoryCache memoryCache)
        {
            municipiosServicio = municipiosServicioIn;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IEnumerable<Municipios> Get()
        {
            //var ListaMunicipios = municipiosServicio.Consultar_Municipios();
            //return ListaMunicipios;

            if (_memoryCache.TryGetValue(municipiosCollectionKey, out IEnumerable<Municipios> municipiosollection))
            {
                return municipiosollection;
            }
            municipiosollection = municipiosServicio.Consultar_Municipios();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(municipiosCollectionKey, municipiosollection);

            return municipiosollection;

        }
        // POST api/<MunicipiosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<MunicipiosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MunicipiosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
