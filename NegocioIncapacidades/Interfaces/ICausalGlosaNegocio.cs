using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades.Interfaces
{
    public interface ICausalGlosaNegocio
    {
        IList<CausalGlosa> Consultar_Todos_Causal_Glosa();
    }
}
