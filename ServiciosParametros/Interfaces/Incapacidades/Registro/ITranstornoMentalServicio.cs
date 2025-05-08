using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
   public interface ITranstornoMentalServicio
    {
        public IEnumerable<TranstornoMental> Consultar_Trasntorno_Mental();
    }
}
