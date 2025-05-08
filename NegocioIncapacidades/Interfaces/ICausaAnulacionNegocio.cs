using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
    public interface ICausaAnulacionNegocio
    {
        IList<CausaAnulacion> Consultar_Todos_Causa_Anulacion();
    }
}
