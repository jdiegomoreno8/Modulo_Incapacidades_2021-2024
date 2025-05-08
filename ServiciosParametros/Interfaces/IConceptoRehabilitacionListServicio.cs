using LibreriasParametros.Modelos;
using System.Collections.Generic;

namespace ServiciosParametros
{
    public interface IConceptoRehabilitacionListServicio
    {
        IList<Concepto_Rehabilitacion> ConsultarConceptoRehabilitacion();
    }
}
