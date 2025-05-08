using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using WebApiIncapacidades.Implementaciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly IDepartamentosServicio departamentoServicio;
        private IMemoryCache _memoryCache;
        private readonly string departamentosCollectionKey = "departamentosCollectionKey";
   

        public DepartamentosController(IDepartamentosServicio departamentosServicioIn, IMemoryCache memoryCache)
        {
            departamentoServicio = departamentosServicioIn;
            _memoryCache = memoryCache;
        }

          

        [HttpGet]
        public IEnumerable<Departamentos> Get()
        {
            //var ListaDepartamentos = departamentoServicio.Consultar_Departamentos();

            if (_memoryCache.TryGetValue(departamentosCollectionKey, out IEnumerable<Departamentos> departamentosCollection))
            {
                return departamentosCollection;
            }
            departamentosCollection = departamentoServicio.Consultar_Departamentos();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(departamentosCollectionKey, departamentosCollection);

            return departamentosCollection;
        }



        // POST api/<DepartamentosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DepartamentosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DepartamentosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
