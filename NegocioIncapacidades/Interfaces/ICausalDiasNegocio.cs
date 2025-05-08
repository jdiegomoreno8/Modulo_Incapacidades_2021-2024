using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades.Interfaces
{
   public interface ICausalDiasNegocio
    {
        IList<CausalDias> Consultar_Todos_Causal_Dias();


    }
}
