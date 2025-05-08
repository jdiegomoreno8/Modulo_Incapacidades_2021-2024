using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades.Interfaces
{
    public interface IConsultaConceptoRehabilitacionNegocio
    {                
        IList<RegistroConceptoRehabilitacion> Consultar_TodosListasConsultarConceptos(Paciente pacienteCR);

    }
}
