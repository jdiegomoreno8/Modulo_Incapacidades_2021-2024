using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
    public interface ICausaAnulacionNegocio
    {
        IList<CausaAnulacion> Consultar_Todos_Causa_Anulacion();
    }
}
