using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
   public interface IMotivaRetroactivaServicio
    {
        public IEnumerable<MotivaRetroactiva> Consultar_Motiva_Retroactiva();
    }
}
