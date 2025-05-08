using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Negocio
{
    public interface IConceptoRehabilitacionNegocio
    {
        IList<IList<Incapacidad>> ConsultaIncapacidad(Paciente paciente);

        string RegistraConcepto(RegistroConceptoRehabilitacion concepto);

        RegistroConceptoRehabilitacion ConsultarCRPorPaciente(Paciente paciente);
    }
}
