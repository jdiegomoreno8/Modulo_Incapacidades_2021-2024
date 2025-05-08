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
    public class EstadoPagoController : ControllerBase
    {
        private readonly IEstadoPagoServicio estadoPagoServicio;
        private IMemoryCache _memoryCache;
        private readonly string estadoPagoCollectionKey = "estadoPagoCollectionKey";
        public EstadoPagoController(IEstadoPagoServicio EstadoPagoServicioIn, IMemoryCache memoryCache)
        {
            estadoPagoServicio = EstadoPagoServicioIn;
            _memoryCache = memoryCache;
        }
        [HttpGet]
        public IEnumerable<EstadoPago> Get()
        {
            //var ListaEstadoPago = estadoPagoServicio.Consultar_Estado_Pago();
            //return ListaEstadoPago;
            if (_memoryCache.TryGetValue(estadoPagoCollectionKey, out IEnumerable<EstadoPago> estadoPagoCollection))
            {
                return estadoPagoCollection;
            }
            estadoPagoCollection = estadoPagoServicio.Consultar_Estado_Pago();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(estadoPagoCollectionKey, estadoPagoCollection);

            return estadoPagoCollection;

        }


    }
}
