using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace NegocioParametros.General
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
            //return departamentosRepositorio.Consultar_Departamentos();
            return (IList<Departamentos>)departamentosRepositorio.Consultar_Departamentos();
        }
    }
}
