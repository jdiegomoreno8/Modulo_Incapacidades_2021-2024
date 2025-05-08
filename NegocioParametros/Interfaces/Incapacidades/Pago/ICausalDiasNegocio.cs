using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
   public interface ICausalDiasNegocio
    {
        IList<CausalDias> Consultar_Todos_Causal_Dias();


    }
}
