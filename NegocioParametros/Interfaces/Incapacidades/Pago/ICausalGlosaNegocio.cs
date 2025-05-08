using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
    public interface ICausalGlosaNegocio
    {
        IList<CausalGlosa> Consultar_Todos_Causal_Glosa();
    }
}
