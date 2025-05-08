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
    public class AdministradorasController : ControllerBase
    {
        // GET: api/<AdministradorasController>
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
    }
}
