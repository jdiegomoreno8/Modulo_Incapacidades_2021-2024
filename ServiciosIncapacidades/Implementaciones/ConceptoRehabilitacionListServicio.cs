using LibreriasIncapacidades.Modelos;
using Negocio;
using NegocioIncapacidades;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
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
