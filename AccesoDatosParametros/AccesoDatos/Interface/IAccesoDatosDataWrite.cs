using LibreriasParametros.Modelos;
using LibreriasParametros.Modelos.DTO;
using LibreriasParametros.Modelos.General;

namespace LibreriasParametros.AccesoDatos
{
    public interface IAccesoDatosDataWrite 
    {
        public RespuestBD InsertarIncapacidad(Incapacidad incapacidad);
        public RespuestBD InsertarPaciente(Paciente pacientes);
        public RespuestBD InsertarPacienteNoEncontrado(PacienteNoEncontrado pacientenoencontrado);
        public RespuestBD InsertarAportante(Aportante aportante);
        public int AnularIncapacidad(IncapacidadAnulada incapacidadanular);
        public RespuestBD InsertarRelacionPacienteAportante(RelacionPacienteAportante relacionPacienteAportante);
        public RespuestBD InsertarRelacionPacienteAfiliacionSalud(RelacionPacienteAfiliacionSalud relacionPacienteAfiliadoSalud);
        public RespuestBD regitrar_concepto_rehabilitacion(RegistroConceptoRehabilitacion conceptoRehabilitacion);
        public RespuestBD Actualizar_Administradora(Administradoras administradora);
    }
}
