using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
    public interface IEstadoPagoServicio
    {
        public IEnumerable<EstadoPago> Consultar_Estado_Pago();
    }
}
