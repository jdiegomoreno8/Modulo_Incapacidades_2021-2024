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
