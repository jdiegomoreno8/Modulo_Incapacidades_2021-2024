using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
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
