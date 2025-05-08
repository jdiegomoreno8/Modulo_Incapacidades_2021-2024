using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
    public interface IEstadoPagoServicio
    {
        public IEnumerable<EstadoPago> Consultar_Estado_Pago();
    }
}
