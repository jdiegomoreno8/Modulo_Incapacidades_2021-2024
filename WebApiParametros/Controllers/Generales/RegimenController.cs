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
    public class RegimenController : ControllerBase
    {
        private readonly IRegimenServicio regimenServicio;
        private IMemoryCache _memoryCache;
        private readonly string regimenCollectionKey = "regimenCollectionKey";
        public RegimenController(IRegimenServicio regimenServicioIn, IMemoryCache memoryCache)
        {
            regimenServicio = regimenServicioIn;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public IEnumerable<Regimen> Get()
        {
            //var ListaRegimen = regimenServicio.Consultar_Regimen();
            //return ListaRegimen;
            if (_memoryCache.TryGetValue(regimenCollectionKey, out IEnumerable<Regimen> regimenCollection))
            {
                return regimenCollection;
            }
            regimenCollection = regimenServicio.Consultar_Regimen();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(regimenCollectionKey, regimenCollection);

            return regimenCollection;
        }


        // POST api/<RegimenController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RegimenController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RegimenController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
