using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;

namespace ServiciosParametros.Incapacidades
{
    public class GrupoServiciosServicio : IGrupoServiciosServicio
    {
        private readonly IGrupoServiciosNegocio grupoServiciosNegocio;
        public GrupoServiciosServicio(IGrupoServiciosNegocio GrupoServiciosNegocioIn)
        {
            grupoServiciosNegocio = GrupoServiciosNegocioIn;
        }
        public IEnumerable<GrupoServicios> Consultar_Grupo_Servicios()
        {
            var ListaGrupoServicios = grupoServiciosNegocio.Consultar_Todos_Grupo_Servicios();
            return ListaGrupoServicios;
        }
    }
}
