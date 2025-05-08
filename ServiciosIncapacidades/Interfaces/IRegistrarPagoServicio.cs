using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
    public interface IRegistrarPagoServicio
    {
        string AdicionarRegistrarPago(RegistrarPago registrarPago);

        IList<RegistrarPago> ConsultarRegistrosPago(RegistrarPago registrarPago);
    }

}
