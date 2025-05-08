using LibreriasIncapacidades.Modelos;
using Negocio;
using System.Collections.Generic;

namespace ServiciosIncapacidades
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
