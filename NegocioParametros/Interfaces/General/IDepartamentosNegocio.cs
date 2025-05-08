using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace NegocioParametros.General
{
   public interface IDepartamentosNegocio
    {
        IList<Departamentos> Consultar_Todos_Departamentos();
    }
}
