using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
   public interface IGrupoServiciosNegocio
    {
        IList<GrupoServicios> Consultar_Todos_Grupo_Servicios();

    }
}
