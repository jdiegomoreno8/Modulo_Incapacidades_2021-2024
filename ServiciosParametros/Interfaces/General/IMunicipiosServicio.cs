using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace ServiciosParametros.General
{
   public interface IMunicipiosServicio
    {
        public IEnumerable<Municipios> Consultar_Municipios();
    }
}
