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
    public class TipoDocumentoController : ControllerBase
    {
        private readonly ITipoDocumentoServicio tipoDocumentoServicio;
        private IMemoryCache _memoryCache;
        private readonly string tipoDocumentoCollectionKey = "tipoDocumentoCollectionKey";
        public TipoDocumentoController(ITipoDocumentoServicio tipoDocumentoServicioIn, IMemoryCache memoryCache)
        {
            tipoDocumentoServicio = tipoDocumentoServicioIn;
            _memoryCache = memoryCache;
        }
        // GET: api/<TipoDocumentoController>
        [HttpGet]
        public IEnumerable<TipoDocumento> Get()
        {
            //var ListaTipoDocumento = tipoDocumentoServicio.Consultar_Tipo_Documento();
            //return ListaTipoDocumento;
            if (_memoryCache.TryGetValue(tipoDocumentoCollectionKey, out IEnumerable<TipoDocumento> tipoDocumentoCollection))
            {
                return tipoDocumentoCollection;
            }
            tipoDocumentoCollection = tipoDocumentoServicio.Consultar_Tipo_Documento();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(tipoDocumentoCollectionKey, tipoDocumentoCollection);

            return tipoDocumentoCollection;
        }

    }
}
