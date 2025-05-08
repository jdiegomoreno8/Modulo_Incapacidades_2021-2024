using LibreriasParametros.Modelos.General;
using Microsoft.AspNetCore.Mvc;
using ServiciosParametros.General;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using WebApiParametros.Utility;
using Microsoft.AspNetCore.Authorization;

namespace WebApiParametros.Controllers.Generales
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorasController : ControllerBase
    {
        private readonly IAdministradoraServicio administradoraServicio;
        private IMemoryCache _memoryCache;
        private readonly string administradoraCollectionKey = "administradoraCollectionKey";
        public AdministradorasController(IAdministradoraServicio administradoraServicioIn, IMemoryCache memoryCache)
        {
            administradoraServicio = administradoraServicioIn;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IEnumerable<Administradoras> Get(string codRegimen, string tipoAdministradora)
        {
            //var ListaAdministradoras = administradoraServicio.Consultar_Administradora(codRegimen, tipoAdministradora);
            //return ListaAdministradoras;

            var keyStore = administradoraCollectionKey + codRegimen + (string.IsNullOrWhiteSpace(tipoAdministradora) ? "" : tipoAdministradora);
            if (_memoryCache.TryGetValue(keyStore, out IEnumerable<Administradoras> administradoraCollection))
            {
                return administradoraCollection;
            }
            administradoraCollection = administradoraServicio.Consultar_Administradora(codRegimen, tipoAdministradora);

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(keyStore, administradoraCollection);

            return administradoraCollection;
        }

        [HttpPut]
        public IEnumerable<Administradoras> Put([FromBody] Administradoras administradora)
        {
            return administradoraServicio.Actualizar_Administradora(administradora);
        }
    }
}
