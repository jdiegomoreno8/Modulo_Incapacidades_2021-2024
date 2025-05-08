using LibreriasIncapacidades.Modelos;
using WebApiIncapacidades.Modelos.DTO;

namespace LibreriasIncapacidades.AccesoDatos
{
    public interface IAccesoDatosDataWrite 
    {
         RespuestBD InsertarIncapacidad(Incapacidad incapacidad);
         RespuestBD InsertarPaciente(Paciente pacientes);
         RespuestBD InsertarPacienteNoEncontrado(PacienteNoEncontrado pacientenoencontrado);
         RespuestBD InsertarAportante(Aportante aportante);
         int AnularIncapacidad(IncapacidadAnulada incapacidadanular);

         RespuestBD InsertarRelacionPacienteAportante(RelacionPacienteAportante relacionPacienteAportante);
         RespuestBD InsertarRelacionPacienteAfiliacionSalud(RelacionPacienteAfiliacionSalud relacionPacienteAfiliadoSalud);
         RespuestBD InsertarRegistrarPago(RegistrarPago registrarPago);
         RespuestBD regitrar_concepto_rehabilitacion(RegistroConceptoRehabilitacion conceptoRehabilitacion);

         RespuestBD InsertarPerdidaCapacidadLaboral(PerdidaCapacidadLaboral pcl);
         void InsertarNotificacion(Notificacion notificacion);
        
         RespuestBD ObtenerSecuenciaPorCodigo(string codigo);

    }
}
