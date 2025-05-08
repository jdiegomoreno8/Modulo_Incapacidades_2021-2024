using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
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
            //return EstadoPagoRepositorio.Consultar_Estado_Pago();
            return (IList<EstadoPago>) EstadoPagoRepositorio.Consultar_Estado_Pago();
        }
    }
}
