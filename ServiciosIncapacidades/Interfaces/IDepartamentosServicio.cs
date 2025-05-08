using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
   public interface IDepartamentosServicio
    {
        public IEnumerable<Departamentos> Consultar_Departamentos();
    }
}
