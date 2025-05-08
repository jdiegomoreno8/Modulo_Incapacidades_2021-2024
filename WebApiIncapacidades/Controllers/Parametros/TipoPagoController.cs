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

namespace WebApiIncapacidades.Controllers.Parametros
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
