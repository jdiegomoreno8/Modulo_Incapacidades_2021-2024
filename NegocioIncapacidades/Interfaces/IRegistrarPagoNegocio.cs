using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades.Interfaces
{
    public interface IRegistrarPagoNegocio
    {
        string NuevoRegistrarPago(RegistrarPago registrarPago);

        IList<RegistrarPago> ConsultarRegistrosPago(RegistrarPago registrarPago);
    }
}
