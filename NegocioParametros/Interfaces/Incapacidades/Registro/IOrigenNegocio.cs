using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
   public interface IOrigenNegocio
    {
        IList<Origen> Consultar_Todos_Origen();

    }
}
