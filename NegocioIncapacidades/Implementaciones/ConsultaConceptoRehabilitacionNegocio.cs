using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
    public class ConsultaConceptoRehabilitacionNegocio: IConsultaConceptoRehabilitacionNegocio
    {
        readonly IAccesoDatosReadOnly consultarConceptosRehabilitacionReadOnly;
        public ConsultaConceptoRehabilitacionNegocio (IAccesoDatosReadOnly consultarConceptosRehabilitacionReadOnlyReposiorioIn)
        {
           
            consultarConceptosRehabilitacionReadOnly = consultarConceptosRehabilitacionReadOnlyReposiorioIn;
        }
  
        public IList<RegistroConceptoRehabilitacion> Consultar_TodosListasConsultarConceptos(Paciente pacienteCR)
        {
            return consultarConceptosRehabilitacionReadOnly.Consultar_TodosListasConsultarConceptos(pacienteCR);

        }

    }
}
