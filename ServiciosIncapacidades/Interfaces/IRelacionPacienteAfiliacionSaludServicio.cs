using LibreriasIncapacidades.Modelos;

namespace ServiciosIncapacidades.Interfaces
{
    public interface IRelacionPacienteAfiliacionSaludServicio
    {
        public string AdicionarRelacionPacienteAfiliacionSalud(RelacionPacienteAfiliacionSalud relacionPacienteAfiliacionSalud);
        RelacionPacienteAfiliacionSalud ConsultarRelacionPacienteAfiliacionSalud(long idPaciente);
    }
}
