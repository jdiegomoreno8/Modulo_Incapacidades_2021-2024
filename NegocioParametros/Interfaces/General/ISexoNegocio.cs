using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace NegocioParametros.General
{
   public interface ISexoNegocio
    {
        IList<Sexo> Consultar_Todos_Sexo();
    }
}
