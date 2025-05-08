using LibreriasIncapacidades.Modelos;
using Negocio;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
{
    public class ConceptoRehabilitacionServicio : IConceptoRehabilitacionServicio
    {

        private readonly IConceptoRehabilitacionNegocio conceptoRehabilitacionNegocio;

        public ConceptoRehabilitacionServicio(IConceptoRehabilitacionNegocio conceptoRehabilitacionNegocioIn)
        {
            conceptoRehabilitacionNegocio = conceptoRehabilitacionNegocioIn;
        }

        public IList<IList<Incapacidad>> ConsultarIncapacidad(Paciente paciente)
        {
            return conceptoRehabilitacionNegocio.ConsultaIncapacidad(paciente);
        }

        public RegistroConceptoRehabilitacion ConsultarPorPaciente(Paciente paciente)
        {
            return conceptoRehabilitacionNegocio.ConsultarCRPorPaciente(paciente);
        }

        public RegistroConceptoRehabilitacion RegistrarConcepto(RegistroConceptoRehabilitacion concepto)
        {
            concepto.id_registro_concepto = conceptoRehabilitacionNegocio.RegistraConcepto(concepto);
            return concepto;
        }
    }
}
