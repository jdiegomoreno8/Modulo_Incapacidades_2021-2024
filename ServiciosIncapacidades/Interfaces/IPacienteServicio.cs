using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
    public interface IPacienteServicio
    {
        Paciente AdicionarPaciente(Paciente pacientes);
        Paciente ConsultarPaciente(string idTipoDocumento, string numeroDocumento, string numeroIncapacidad);
        PacienteNoEncontrado ConsultarPacienteNoEncontrado(string idTipoDocumento, string numeroDocumento);
    }
}
