using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
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
    public class ConceptoRehabilitacionListController : ControllerBase
    {
        private readonly IConceptoRehabilitacionListServicio conceptoRehabilitacionList;
        private IMemoryCache _memoryCache;
        private readonly string conceptoRehabilitacionListCollectionKey = "conceptoRehabilitacionListCollectionKey";
        public ConceptoRehabilitacionListController(IConceptoRehabilitacionListServicio conceptoRehabilitacionListIn, IMemoryCache memoryCache)
        {
            conceptoRehabilitacionList = conceptoRehabilitacionListIn;
            _memoryCache = memoryCache;

        }
        // GET: api/<ConceptoRehabilitacionListController>
        [HttpGet]
        public IEnumerable<Concepto_Rehabilitacion> Get()
        {
            //var ListaConceptoRehabilitacion = conceptoRehabilitacionList.ConsultarConceptoRehabilitacion();
            //return ListaConceptoRehabilitacion;

            if (_memoryCache.TryGetValue(conceptoRehabilitacionListCollectionKey, out IEnumerable<Concepto_Rehabilitacion> conceptoRehabilitacionListCollection))
            {
                return conceptoRehabilitacionListCollection;
            }
            conceptoRehabilitacionListCollection = conceptoRehabilitacionList.ConsultarConceptoRehabilitacion();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(conceptoRehabilitacionListCollectionKey, conceptoRehabilitacionListCollection);

            return conceptoRehabilitacionListCollection;
        }
        //// GET: api/<ConceptoRehabilitacionList>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<ConceptoRehabilitacionList>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<ConceptoRehabilitacionList>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<ConceptoRehabilitacionList>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<ConceptoRehabilitacionList>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
