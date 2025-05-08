using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades.Implementaciones
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
            return tipoPagoRepositorio.Consultar_Tipo_Pago();
        }
    }
}
