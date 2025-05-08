using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
    public interface ICausalDiasServicio
    {
        public IEnumerable<CausalDias> Consultar_Causal_Dias();
    }
}
