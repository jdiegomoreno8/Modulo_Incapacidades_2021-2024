using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
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
