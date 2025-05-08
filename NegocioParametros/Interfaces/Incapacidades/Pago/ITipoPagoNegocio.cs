using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
   public interface ITipoPagoNegocio
    {
        IList<TipoPago> Consultar_Todos_Tipo_Pago();
    }
}
