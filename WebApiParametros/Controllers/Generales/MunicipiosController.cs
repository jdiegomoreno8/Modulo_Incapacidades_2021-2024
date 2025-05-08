using LibreriasParametros.Modelos.General;
using Microsoft.AspNetCore.Mvc;
using ServiciosParametros.General;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using WebApiParametros.Utility;
using Microsoft.AspNetCore.Authorization;

namespace WebApiParametros.Controllers.Generales
{

    [Authorize]
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
