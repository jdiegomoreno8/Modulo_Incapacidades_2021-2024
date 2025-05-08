using LibreriasParametros.Modelos.General;
using System.Collections.Generic;
using NegocioParametros.General;

namespace ServiciosParametros.General
{
   public class DepartamentosServicio : IDepartamentosServicio
    {
        private readonly IDepartamentosNegocio departamentosNegocio;
        public DepartamentosServicio(IDepartamentosNegocio DepartamentosNegocioIn)
        {
            departamentosNegocio = DepartamentosNegocioIn;
        }

        public IEnumerable<Departamentos> Consultar_Departamentos()
        {
            var ListaDepartamentos = departamentosNegocio.Consultar_Todos_Departamentos();
            return ListaDepartamentos;
        }
    }
}
