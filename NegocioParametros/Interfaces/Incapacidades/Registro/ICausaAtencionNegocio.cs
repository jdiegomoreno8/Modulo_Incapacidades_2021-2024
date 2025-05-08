using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace NegocioParametros.Incapacidades
{
    public interface ICausaAtencionNegocio
    {
        IList<CausaAtencion> Consultar_Todos_Causa_Motivo_Atencion();
    }
}
