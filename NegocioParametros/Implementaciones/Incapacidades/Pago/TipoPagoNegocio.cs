using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
  public  class TipoPagoNegocio : ITipoPagoNegocio
    {
        readonly IAccesoDatosReadOnly tipoPagoRepositorio;
        public TipoPagoNegocio(IAccesoDatosReadOnly tipoPagoRepositorioIn)
        {
            tipoPagoRepositorio = tipoPagoRepositorioIn;
        }
        public IList<TipoPago> Consultar_Todos_Tipo_Pago()
        {
            //return tipoPagoRepositorio.Consultar_Tipo_Pago();
            return (IList<TipoPago>) tipoPagoRepositorio.Consultar_Tipo_Pago();
        }
    }
}
