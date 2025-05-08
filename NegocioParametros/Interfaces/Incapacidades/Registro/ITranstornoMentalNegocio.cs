using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
   public interface ITranstornoMentalNegocio
    {
        IList<TranstornoMental> Consultar_Todos_Trasntorno_Mental();
    }
}
