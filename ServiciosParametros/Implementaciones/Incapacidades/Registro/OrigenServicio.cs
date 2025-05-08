using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;


namespace ServiciosParametros.Incapacidades
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
