using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades.Interfaces
{
    public interface IEstadoPagoNegocio
    {
        IList<EstadoPago> Consultar_Todos_Estado_Pago();
    }
}
