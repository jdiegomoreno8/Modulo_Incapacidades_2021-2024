using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
    public class OrigenServicio : IOrigenServicio
    {
        private readonly IOrigenNegocio OrigenNegocio;
        public OrigenServicio(IOrigenNegocio OrigenNegocioIn)
        {
            OrigenNegocio = OrigenNegocioIn;
        }

        public IEnumerable<Origen> Consultar_Origen()
        {
            var ListaOrigen = OrigenNegocio.Consultar_Todos_Origen();
            return ListaOrigen;
        }

    }
}
