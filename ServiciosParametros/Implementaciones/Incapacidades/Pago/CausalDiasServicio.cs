using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;

namespace ServiciosParametros.Incapacidades
{
   public class CausalDiasServicio : ICausalDiasServicio
    {
        private readonly ICausalDiasNegocio causalDiasNegocio;
        public CausalDiasServicio(ICausalDiasNegocio causalDiasNegocioIn)
        {
            causalDiasNegocio = causalDiasNegocioIn;
        }

        public IEnumerable<CausalDias> Consultar_Causal_Dias()
        {
            var ListaCausalDias = causalDiasNegocio.Consultar_Todos_Causal_Dias();
            return ListaCausalDias;
        }
    }
}
