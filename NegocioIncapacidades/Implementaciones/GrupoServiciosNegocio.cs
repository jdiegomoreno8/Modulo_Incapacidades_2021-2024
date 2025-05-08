using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;

namespace Negocio
{
   public class GrupoServiciosNegocio : IGrupoServiciosNegocio
    {
        readonly IAccesoDatosReadOnly grupoServicioRepositorio;

        public GrupoServiciosNegocio(IAccesoDatosReadOnly grupoServicioRepositorioIn)
        {
            grupoServicioRepositorio = grupoServicioRepositorioIn;
        }
        public IList<GrupoServicios> Consultar_Todos_Grupo_Servicios()
        {
            return grupoServicioRepositorio.Consultar_Grupo_Servicios();
        }

    }
}
