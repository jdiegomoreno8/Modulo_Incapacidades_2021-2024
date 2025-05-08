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
