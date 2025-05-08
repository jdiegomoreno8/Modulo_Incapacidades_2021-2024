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
    public class SexoController : ControllerBase
    {
        private readonly ISexoServicio sexoServicio;
        private IMemoryCache _memoryCache;
        private readonly string sexoCollectionKey = "sexoCollectionKey";
        public SexoController(ISexoServicio sexoServicioIn, IMemoryCache memoryCache)
        {
            sexoServicio = sexoServicioIn;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public IEnumerable<Sexo> Get()
        {
            //var ListaSexo = sexoServicio.Consultar_Sexo();
            //return ListaSexo;
            if (_memoryCache.TryGetValue(sexoCollectionKey, out IEnumerable<Sexo> sexoCollection))
            {
                return sexoCollection;
            }
            sexoCollection = sexoServicio.Consultar_Sexo();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(sexoCollectionKey, sexoCollection);

            return sexoCollection;
        }
        // POST api/<SexoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SexoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SexoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
