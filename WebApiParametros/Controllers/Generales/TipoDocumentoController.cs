using LibreriasParametros.Modelos.General;
using Microsoft.AspNetCore.Mvc;
using ServiciosParametros.General;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using WebApiParametros.Utility;
using Microsoft.AspNetCore.Authorization;

namespace WebApiIncapacidades.Controllers.Generales
{
    [Authorize]
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
