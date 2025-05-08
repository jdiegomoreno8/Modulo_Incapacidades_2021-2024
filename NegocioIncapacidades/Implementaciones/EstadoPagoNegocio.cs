using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades.Implementaciones
{
    public class EstadoPagoNegocio : IEstadoPagoNegocio
    {
        readonly IAccesoDatosReadOnly EstadoPagoRepositorio;
        public EstadoPagoNegocio(IAccesoDatosReadOnly estadoPagoRepositorioIn)
        {
            EstadoPagoRepositorio = estadoPagoRepositorioIn;
        }
        public IList<EstadoPago> Consultar_Todos_Estado_Pago()
        {
            return EstadoPagoRepositorio.Consultar_Estado_Pago();
        }
    }
}
