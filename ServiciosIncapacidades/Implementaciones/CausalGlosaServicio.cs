using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
{
    public class CausalGlosaServicio : ICausalGlosaServicio
    {
        private readonly ICausalGlosaNegocio causalGlosaNegocio;
        public CausalGlosaServicio(ICausalGlosaNegocio causalGlosaNegocioIn)
        {
            causalGlosaNegocio = causalGlosaNegocioIn;
        }

        public IEnumerable<CausalGlosa> Consultar_Causal_Glosa()
        {
            var ListaCausalGlosa = causalGlosaNegocio.Consultar_Todos_Causal_Glosa();
            return ListaCausalGlosa;
        }
    }
}
