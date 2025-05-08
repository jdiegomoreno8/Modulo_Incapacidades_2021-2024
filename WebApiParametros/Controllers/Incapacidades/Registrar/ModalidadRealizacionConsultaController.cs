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
    public class ModalidadRealizacionConsultaController : ControllerBase
    {
        private readonly IModalidadRealizacionConsultaServicio modalidadRealizacionConsultaServicio;
        private IMemoryCache _memoryCache;
        private readonly string modalidadRealizacionConsultaCollectionKey = "modalidadRealizacionConsultaCollectionKey";

        public ModalidadRealizacionConsultaController(IModalidadRealizacionConsultaServicio modalidadRealizacionConsultaServicioIn, IMemoryCache memoryCache)
        {
            modalidadRealizacionConsultaServicio = modalidadRealizacionConsultaServicioIn;
            _memoryCache = memoryCache;
        }

        [HttpGet]
        public IEnumerable<ModalidadRealizacionConsulta> Get()
        {
            //var ListaModalidadRealizacionConsulta = modalidadRealizacionConsultaServicio.Consultar_Modalidad_Realizacion_Consulta();
            //return ListaModalidadRealizacionConsulta;
            if (_memoryCache.TryGetValue(modalidadRealizacionConsultaCollectionKey, out IEnumerable<ModalidadRealizacionConsulta> modalidadRealizacionConsultaCollection))
            {
                return modalidadRealizacionConsultaCollection;
            }
            modalidadRealizacionConsultaCollection = modalidadRealizacionConsultaServicio.Consultar_Modalidad_Realizacion_Consulta();

            _memoryCache = CachePolicy.InitMemoryCache(_memoryCache);
            _memoryCache.Set(modalidadRealizacionConsultaCollectionKey, modalidadRealizacionConsultaCollection);

            return modalidadRealizacionConsultaCollection;
        }
    }
}
