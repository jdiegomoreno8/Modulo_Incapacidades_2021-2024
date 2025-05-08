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
