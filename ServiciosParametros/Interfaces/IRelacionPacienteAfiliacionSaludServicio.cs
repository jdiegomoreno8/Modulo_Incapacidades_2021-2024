using LibreriasParametros.Modelos;

namespace ServiciosParametros
{
    public interface IRelacionPacienteAfiliacionSaludServicio
    {
        public string AdicionarRelacionPacienteAfiliacionSalud(RelacionPacienteAfiliacionSalud relacionPacienteAfiliacionSalud);
        RelacionPacienteAfiliacionSalud ConsultarRelacionPacienteAfiliacionSalud(long idPaciente);
    }
}
