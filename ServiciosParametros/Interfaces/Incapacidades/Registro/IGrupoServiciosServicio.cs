using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
    public interface IGrupoServiciosServicio
    {
        public IEnumerable<GrupoServicios> Consultar_Grupo_Servicios();
    }
}
