using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
   public class OrigenNegocio : IOrigenNegocio
    {
        readonly IAccesoDatosReadOnly origenRepositorio;

        public OrigenNegocio(IAccesoDatosReadOnly origenRepositorioIn)
        {
            origenRepositorio = origenRepositorioIn;
        }
        public IList<Origen> Consultar_Todos_Origen()
        {
            //return origenRepositorio.Consultar_Origen();
            return (IList <Origen>) origenRepositorio.Consultar_Origen();
        }

    }
}
