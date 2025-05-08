using LibreriasParametros.Modelos;
using System.Collections.Generic;
using NegocioParametros;

namespace ServiciosParametros
{
    public class ConceptoRehabilitacionListServicio : IConceptoRehabilitacionListServicio
    {

        private readonly IConceptoRehabilitacionListNegocio conceptoRehabilitacionListNegocio;

        public ConceptoRehabilitacionListServicio(IConceptoRehabilitacionListNegocio conceptoRehabilitacionListNegocioIn)
        {
            conceptoRehabilitacionListNegocio = conceptoRehabilitacionListNegocioIn;
        }

        public IList<Concepto_Rehabilitacion> ConsultarConceptoRehabilitacion()
        {
            return conceptoRehabilitacionListNegocio.Consultar_Todos_Conpceto_Rehabilitacion();
        }


    }
}
