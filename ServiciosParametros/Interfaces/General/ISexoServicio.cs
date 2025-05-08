using LibreriasParametros.Modelos.General;
using System.Collections.Generic;


namespace ServiciosParametros.General
{
   public interface ISexoServicio
    {
        public IEnumerable<Sexo> Consultar_Sexo();
    }
}
