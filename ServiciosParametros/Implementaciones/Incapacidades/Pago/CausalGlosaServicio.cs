using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using NegocioParametros.Incapacidades;

namespace ServiciosParametros.Incapacidades
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
