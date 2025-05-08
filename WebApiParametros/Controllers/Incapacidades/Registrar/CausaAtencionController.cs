using LibreriasParametros.Modelos.Incapacidades;
using Microsoft.AspNetCore.Mvc;
using ServiciosParametros.Incapacidades;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using WebApiParametros.Utility;

namespace WebApiParametros.Controllers.Incapacidades
{
    [Route("api/[controller]")]
    [ApiController]
    public class CausaAtencionController : ControllerBase
    {
        private readonly ICausaAtencionServicio causaAtencionServicio;
        private IMemoryCache _memoryCache;
        private readonly string causaAtencionCollectionKey = "causaAtencionCollectionKey";
        public CausaAtencionController(ICausaAtencionServicio causaAtencionServicioIn, IMemoryCache memoryCache)
        {
            causaAtencionServicio = causaAtencionServicioIn;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public IEnumerable<CausaAtencion> Get()
        {
            //var ListaCausaAtencion = causaAtencionServicio.Consultar_Causa_Motivo_Atencion();
            // return ListaCausaAtencion;

            if (_memoryCache.TryGetValue(causaAtencionCollectionKey, out IEnumerable<CausaAtencion> causaAtencionCollection))
            {
                return causaAtencionCollection;
            }
            causaAtencionCollection = causaAtencionServicio.Consultar_Causa_Motivo_Atencion();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(causaAtencionCollectionKey, causaAtencionCollection);

            return causaAtencionCollection;
        }

   
    }
}
