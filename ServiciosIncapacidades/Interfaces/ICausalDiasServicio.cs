using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
    public interface ICausalDiasServicio
    {
        public IEnumerable<CausalDias> Consultar_Causal_Dias();
    }
}
