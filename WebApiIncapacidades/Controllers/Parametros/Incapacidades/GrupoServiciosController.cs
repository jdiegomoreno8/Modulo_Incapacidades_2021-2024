using LibreriasIncapacidades.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using WebApiIncapacidades.Implementaciones;

namespace WebApiIncapacidades.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoServiciosController : ControllerBase
    {
        private readonly IGrupoServiciosServicio grupoServiciosServicio;
        private IMemoryCache _memoryCache;
        private readonly string grupoServiciosCollectionKey = "grupoServiciosCollectionKey";


        public GrupoServiciosController(IGrupoServiciosServicio grupoServiciosServicioIn, IMemoryCache memoryCache)
        {
            grupoServiciosServicio = grupoServiciosServicioIn;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IEnumerable<GrupoServicios> Get()
        {
            //var ListaGrupoServicios = grupoServiciosServicio.Consultar_Grupo_Servicios();
            //return ListaGrupoServicios;             
            if (_memoryCache.TryGetValue(grupoServiciosCollectionKey, out IEnumerable<GrupoServicios> grupoServiciosCollection))
            {
                return grupoServiciosCollection;
            }
            grupoServiciosCollection = grupoServiciosServicio.Consultar_Grupo_Servicios();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(grupoServiciosCollectionKey, grupoServiciosCollection);

            return grupoServiciosCollection;
        }

    }
}
