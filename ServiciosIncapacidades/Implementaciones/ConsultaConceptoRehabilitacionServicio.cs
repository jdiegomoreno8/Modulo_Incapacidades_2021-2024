using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using NegocioIncapacidades.Implementaciones;
using NegocioIncapacidades.Interfaces;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
{
    public class ConsultaConceptoRehabilitacionServicio: IConsultaConceptoRehabilitacionServicio
    {
        private readonly IConsultaConceptoRehabilitacionNegocio consultaConceptoRehabilitacionNegocio;

        public ConsultaConceptoRehabilitacionServicio(IConsultaConceptoRehabilitacionNegocio consultarConceptosRehabilitacionNegocioIn) {

            consultaConceptoRehabilitacionNegocio = consultarConceptosRehabilitacionNegocioIn;
        }

 

        public IEnumerable<RegistroConceptoRehabilitacion> Consultar_ListasConceptosRehabilitacion(Paciente pacienteCR)
        {
            var consultarConceptosRehabilitacion = consultaConceptoRehabilitacionNegocio.Consultar_TodosListasConsultarConceptos(pacienteCR);
            return consultarConceptosRehabilitacion;
        }
    }
}
