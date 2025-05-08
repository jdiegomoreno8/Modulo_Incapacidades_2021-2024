using LibreriasParametros.Modelos;
using System.Collections.Generic;

namespace ServiciosParametros
{
    public interface IConceptoRehabilitacionServicio
    {
        IList<IList<Incapacidad>> ConsultarIncapacidad(Paciente paciente);

        RegistroConceptoRehabilitacion RegistrarConcepto(RegistroConceptoRehabilitacion concepto);

        RegistroConceptoRehabilitacion ConsultarPorPaciente(Paciente paciente);
    }
}
