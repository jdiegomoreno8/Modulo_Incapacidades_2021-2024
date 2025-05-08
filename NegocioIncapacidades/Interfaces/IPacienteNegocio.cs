using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
   public interface IPacienteNegocio
    {
        string NuevoPaciente(Paciente paciente);

        string NuevoAportante(Aportante aportante);

        Paciente ObtenerPaciente(string idTipoDocumento, string numeroDocumento, string numeroIncapacidad);

        PacienteNoEncontrado ObtenerPacienteNoEncontrado(string idTipoDocumento, string numeroDocumento);
    }
}
