using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace ServiciosParametros.General
{
   public interface IDepartamentosServicio
    {
        public IEnumerable<Departamentos> Consultar_Departamentos();
    }
}
