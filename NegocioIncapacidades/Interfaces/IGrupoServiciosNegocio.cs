using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;

namespace Negocio
{
   public interface IGrupoServiciosNegocio
    {
        IList<GrupoServicios> Consultar_Todos_Grupo_Servicios();

    }
}
