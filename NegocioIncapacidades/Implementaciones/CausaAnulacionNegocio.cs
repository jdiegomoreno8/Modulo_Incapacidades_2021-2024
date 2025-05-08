using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
    public class CausaAnulacionNegocio : ICausaAnulacionNegocio
    {
        readonly IAccesoDatosReadOnly causaAnulacionRepositorio;

        public CausaAnulacionNegocio(IAccesoDatosReadOnly causaAnulacionRepositorioIn)
        {
            causaAnulacionRepositorio = causaAnulacionRepositorioIn;
        }
        public IList<CausaAnulacion> Consultar_Todos_Causa_Anulacion()
        {
            return causaAnulacionRepositorio.Consultar_Causa_Anulacion();
        }
    }
}
