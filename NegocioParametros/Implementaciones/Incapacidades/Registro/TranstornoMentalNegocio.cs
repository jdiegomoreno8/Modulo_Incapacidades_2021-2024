using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
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
            //return transtornoMentalRepositorio.Consultar_Transtorno_Mental();
            return (IList<TranstornoMental>) transtornoMentalRepositorio.Consultar_Transtorno_Mental();
        }

    }
}
