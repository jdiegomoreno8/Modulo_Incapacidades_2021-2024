using LibreriasParametros.Modelos;


namespace NegocioParametros
{
   public interface IRelacionPacienteAfiliacionSaludNegocio
    {
        string NuevoRelacionPacienteAfiliacionSalud(RelacionPacienteAfiliacionSalud relacionPacienteAfiliacionSalud);
        RelacionPacienteAfiliacionSalud ConsultarRelacionPacienteAfiliacionSalud(long idPaciente);

    }
}
