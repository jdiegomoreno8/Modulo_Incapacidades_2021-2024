using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos;

namespace NegocioParametros
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
