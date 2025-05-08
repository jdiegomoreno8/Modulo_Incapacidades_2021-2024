using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
    public interface IConceptoRehabilitacionListNegocio
    {
        IList<Concepto_Rehabilitacion> Consultar_Todos_Conpceto_Rehabilitacion();
    }
}
