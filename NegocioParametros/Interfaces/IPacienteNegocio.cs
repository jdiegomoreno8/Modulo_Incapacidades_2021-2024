using LibreriasParametros.Modelos;

namespace NegocioParametros
{
   public interface IPacienteNegocio
    {
        string NuevoPaciente(Paciente paciente);

        string NuevoAportante(Aportante aportante);

        Paciente ObtenerPaciente(string idTipoDocumento, string numeroDocumento, string numeroIncapacidad);

        PacienteNoEncontrado ObtenerPacienteNoEncontrado(string idTipoDocumento, string numeroDocumento);
    }
}
