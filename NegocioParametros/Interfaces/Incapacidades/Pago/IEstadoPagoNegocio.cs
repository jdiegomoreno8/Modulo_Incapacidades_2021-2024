using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
    public interface IEstadoPagoNegocio
    {
        IList<EstadoPago> Consultar_Todos_Estado_Pago();
    }
}
