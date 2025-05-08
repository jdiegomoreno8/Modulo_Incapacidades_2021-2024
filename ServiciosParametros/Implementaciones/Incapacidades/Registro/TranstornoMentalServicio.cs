using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;


namespace ServiciosParametros.Incapacidades
{
    public class TranstornoMentalServicio: ITranstornoMentalServicio
    {
        private readonly ITranstornoMentalNegocio TranstornoMentalNegocio;
        public TranstornoMentalServicio(ITranstornoMentalNegocio TranstornoMentalNegocioIn)
        {
            TranstornoMentalNegocio = TranstornoMentalNegocioIn;
        }

        public IEnumerable<TranstornoMental> Consultar_Trasntorno_Mental()
        {
            var ListaTranstornoMental = TranstornoMentalNegocio.Consultar_Todos_Trasntorno_Mental();
            return ListaTranstornoMental;
        }
    }
}
