using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
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
            //return causalDiasRepositorio.Consultar_Causal_Dias();
            return (IList<CausalDias>)causalDiasRepositorio.Consultar_Causal_Dias();
        }
    }
}
