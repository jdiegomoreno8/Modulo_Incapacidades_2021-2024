using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
   public interface ITranstornoMentalServicio
    {
        public IEnumerable<TranstornoMental> Consultar_Trasntorno_Mental();
    }
}
