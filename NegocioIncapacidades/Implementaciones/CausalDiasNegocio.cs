using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades.Implementaciones
{
   public class CausalDiasNegocio : ICausalDiasNegocio
    {
        readonly IAccesoDatosReadOnly causalDiasRepositorio;
        public CausalDiasNegocio(IAccesoDatosReadOnly causalDiasRepositorioIn)
        {
            causalDiasRepositorio = causalDiasRepositorioIn;
        }
        public IList<CausalDias> Consultar_Todos_Causal_Dias()
        {
            return causalDiasRepositorio.Consultar_Causal_Dias();
        }
    }
}
