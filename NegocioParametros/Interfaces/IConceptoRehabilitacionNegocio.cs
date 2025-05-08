using LibreriasParametros.Modelos;
using System.Collections.Generic;

namespace NegocioParametros
{
    public interface IConceptoRehabilitacionNegocio
    {
        IList<IList<Incapacidad>> ConsultaIncapacidad(Paciente paciente);

        string RegistraConcepto(RegistroConceptoRehabilitacion concepto);

        RegistroConceptoRehabilitacion ConsultarCRPorPaciente(Paciente paciente);
    }
}
