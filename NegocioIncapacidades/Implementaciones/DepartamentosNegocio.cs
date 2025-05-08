using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
   public class DepartamentosNegocio : IDepartamentosNegocio
    {
        readonly IAccesoDatosReadOnly departamentosRepositorio;

        public DepartamentosNegocio(IAccesoDatosReadOnly departamentosRepositorioIn)
        {
            departamentosRepositorio = departamentosRepositorioIn;
        }
        public IList<Departamentos> Consultar_Todos_Departamentos()
        {
            return departamentosRepositorio.Consultar_Departamentos();
        }
    }
}
