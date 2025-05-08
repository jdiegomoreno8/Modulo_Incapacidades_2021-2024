using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
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
            return origenRepositorio.Consultar_Origen();
        }

    }
}
