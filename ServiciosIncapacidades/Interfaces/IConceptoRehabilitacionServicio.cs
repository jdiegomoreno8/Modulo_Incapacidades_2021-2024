using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
    public interface IConceptoRehabilitacionServicio
    {
        IList<IList<Incapacidad>> ConsultarIncapacidad(Paciente paciente);

        RegistroConceptoRehabilitacion RegistrarConcepto(RegistroConceptoRehabilitacion concepto);

        RegistroConceptoRehabilitacion ConsultarPorPaciente(Paciente paciente);
    }
}
