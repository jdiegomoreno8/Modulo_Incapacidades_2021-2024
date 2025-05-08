using LibreriasParametros.Modelos.Incapacidades;
using Microsoft.AspNetCore.Mvc;
using ServiciosParametros.Incapacidades;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using WebApiParametros.Utility;
using Microsoft.AspNetCore.Authorization;

namespace WebApiParametros.Controllers.Incapacidades
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
        [Authorize]
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
