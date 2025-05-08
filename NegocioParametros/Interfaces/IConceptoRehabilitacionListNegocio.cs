using LibreriasParametros.Modelos;
using System.Collections.Generic;

namespace NegocioParametros
{
    public interface IConceptoRehabilitacionListNegocio
    {
        IList<Concepto_Rehabilitacion> Consultar_Todos_Conpceto_Rehabilitacion();
    }
}
