using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades.Implementaciones
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
            return CausalGlosaRepositorio.Consultar_Causal_Glosa();
        }
    }
}
