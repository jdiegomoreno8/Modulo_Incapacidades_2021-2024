using LibreriasParametros.Modelos;


namespace ServiciosParametros
{
    public interface IPacienteServicio
    {
        Paciente AdicionarPaciente(Paciente pacientes);
        Paciente ConsultarPaciente(string idTipoDocumento, string numeroDocumento, string numeroIncapacidad);
        PacienteNoEncontrado ConsultarPacienteNoEncontrado(string idTipoDocumento, string numeroDocumento);
    }
}
