using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
   public interface IMunicipiosServicio
    {
        public IEnumerable<Municipios> Consultar_Municipios();
    }
}
