using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
   public interface IMotivaRetroactivaServicio
    {
        public IEnumerable<MotivaRetroactiva> Consultar_Motiva_Retroactiva();
    }
}
