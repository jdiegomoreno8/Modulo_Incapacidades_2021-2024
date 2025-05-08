using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades.Implementaciones
{
  public  class ConsultarRegistroPagoNegocio : IConsultarRegistroPagoNegocio
    {
        readonly IAccesoDatosReadOnly registroPagoRepositorioReadOnly;
        public ConsultarRegistroPagoNegocio(IAccesoDatosReadOnly registroPagoRepositorioReadOnlyIn)
        {

            registroPagoRepositorioReadOnly = registroPagoRepositorioReadOnlyIn;
        }
        public string ObtenerTodosConsultaRegistroPago(ConsultarRegistroPago consultarRegistroPago)
        {
            return registroPagoRepositorioReadOnly.Consultar_Incapacidad_Registrar_Pago(consultarRegistroPago);
        }


    }
}
