using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
    public interface ICausalGlosaServicio
    {
        public IEnumerable<CausalGlosa> Consultar_Causal_Glosa();
    }
}
