using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using System.Linq;
using System.Threading.Tasks;
using WebApiIncapacidades.Implementaciones;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiIncapacidades.Controllers
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
