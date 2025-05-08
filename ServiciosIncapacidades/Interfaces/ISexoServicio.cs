using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
   public interface ISexoServicio
    {
        public IEnumerable<Sexo> Consultar_Sexo();
    }
}
