using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades.Implementaciones
{
    public class RegistrarPagoNegocio : IRegistrarPagoNegocio
    {
        readonly IAccesoDatosDataWrite RegistrarPagoRepositorio;
        readonly IAccesoDatosReadOnly RegistrarPagoRepositorioReadOnly;
        public RegistrarPagoNegocio(IAccesoDatosDataWrite registrarPagoRepositorioIn, IAccesoDatosReadOnly registrarPagoRepositorioReadOnlyIn)
        {
            RegistrarPagoRepositorio = registrarPagoRepositorioIn;
            RegistrarPagoRepositorioReadOnly = registrarPagoRepositorioReadOnlyIn;
        }

        public string NuevoRegistrarPago(RegistrarPago registrarPago)
        {
            return RegistrarPagoRepositorio.InsertarRegistrarPago(registrarPago).resultado;
        }

        public IList<RegistrarPago> ConsultarRegistrosPago(RegistrarPago registrarPago)
        {
            return RegistrarPagoRepositorioReadOnly.Consultar_Incapacidad_Pagada(registrarPago);
        }
    }
}
