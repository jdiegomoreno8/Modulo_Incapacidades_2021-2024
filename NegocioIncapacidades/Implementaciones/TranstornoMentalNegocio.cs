using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System.Collections.Generic;

namespace NegocioIncapacidades
{
   public class TranstornoMentalNegocio : ITranstornoMentalNegocio
    {
        readonly IAccesoDatosReadOnly transtornoMentalRepositorio;

        public TranstornoMentalNegocio(IAccesoDatosReadOnly transtornoMentalRepositorioIn)
        {
            transtornoMentalRepositorio = transtornoMentalRepositorioIn;
        }
        public IList<TranstornoMental> Consultar_Todos_Trasntorno_Mental()
        {
            return transtornoMentalRepositorio.Consultar_Transtorno_Mental();
        }

    }
}
