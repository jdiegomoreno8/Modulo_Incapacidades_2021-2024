using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
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
