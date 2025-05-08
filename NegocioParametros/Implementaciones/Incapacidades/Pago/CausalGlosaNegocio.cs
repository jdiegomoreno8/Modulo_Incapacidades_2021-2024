using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
    public class CausalGlosaNegocio : ICausalGlosaNegocio
    {
        readonly IAccesoDatosReadOnly CausalGlosaRepositorio;
        public CausalGlosaNegocio(IAccesoDatosReadOnly causalGlosaPagoRepositorioIn)
        {
            CausalGlosaRepositorio = causalGlosaPagoRepositorioIn;
        }
        public IList<CausalGlosa> Consultar_Todos_Causal_Glosa()
        {
            //return CausalGlosaRepositorio.Consultar_Causal_Glosa();
            return (IList<CausalGlosa>) CausalGlosaRepositorio.Consultar_Causal_Glosa();
        }
    }
}
