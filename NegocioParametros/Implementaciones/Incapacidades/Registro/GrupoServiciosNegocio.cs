using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
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
            //return grupoServicioRepositorio.Consultar_Grupo_Servicios();
            return (IList<GrupoServicios>) grupoServicioRepositorio.Consultar_Grupo_Servicios();
        }

    }
}
