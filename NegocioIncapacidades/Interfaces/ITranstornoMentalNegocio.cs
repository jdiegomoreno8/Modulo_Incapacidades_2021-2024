using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;

namespace NegocioIncapacidades
{
   public interface ITranstornoMentalNegocio
    {
        IList<TranstornoMental> Consultar_Todos_Trasntorno_Mental();
    }
}
