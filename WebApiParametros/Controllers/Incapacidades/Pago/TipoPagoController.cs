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
    public class TipoPagoController : ControllerBase
    {
        private readonly ITipoPagoServicio tipoPagoServicio;
        private IMemoryCache _memoryCache;
        private readonly string tipoPagoCollectionKey = "tipoPagoCollectionKey";
        public TipoPagoController(ITipoPagoServicio tipoPagoServicioIn, IMemoryCache memoryCache)
        {
            tipoPagoServicio = tipoPagoServicioIn;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public IEnumerable<TipoPago> Get()
        {
            //var ListaTipoPago = tipoPagoServicio.Consultar_Tipo_Pago();
            //return ListaTipoPago;
            if (_memoryCache.TryGetValue(tipoPagoCollectionKey, out IEnumerable<TipoPago> tipoPagoCollection))
            {
                return tipoPagoCollection;
            }
            tipoPagoCollection = tipoPagoServicio.Consultar_Tipo_Pago();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(tipoPagoCollectionKey, tipoPagoCollection);

            return tipoPagoCollection;
        }
    }
}
