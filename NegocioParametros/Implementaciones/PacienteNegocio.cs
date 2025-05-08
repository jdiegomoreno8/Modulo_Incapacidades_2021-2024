using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos;
using System.Globalization;

namespace NegocioParametros
{
   public class PacienteNegocio : IPacienteNegocio
    {
        readonly IAccesoDatosDataWrite pacientesRepositorioWrite;
        readonly IAccesoDatosReadOnly pacientesRepositorioReadOnly;

        public PacienteNegocio(IAccesoDatosDataWrite pacientesRepositorioWriteIn, IAccesoDatosReadOnly pacientesRepositorioReadOnlyIn)
        {
            pacientesRepositorioWrite = pacientesRepositorioWriteIn;
            pacientesRepositorioReadOnly = pacientesRepositorioReadOnlyIn;
        }

        public string NuevoPaciente(Paciente paciente)
        {
            return pacientesRepositorioWrite.InsertarPaciente(paciente).resultado;
        }

        public string NuevoAportante(Aportante aportante)
        {
            return pacientesRepositorioWrite.InsertarAportante(aportante).resultado;
        }

        public Paciente ObtenerPaciente(string idTipoDocumento, string numeroDocumento, string numeroIncapacidad)
        {
            var paciente = pacientesRepositorioReadOnly.ObtenerPaciente(idTipoDocumento, numeroDocumento, numeroIncapacidad);

            paciente.fecha_nacimiento_string = paciente.fecha_nacimiento.HasValue ? paciente.fecha_nacimiento.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture) : "";

            return paciente;
        }

        public PacienteNoEncontrado ObtenerPacienteNoEncontrado(string idTipoDocumento, string numeroDocumento)
        {
            var paciente = pacientesRepositorioReadOnly.ObtenerPacienteNoEncontrado(idTipoDocumento, numeroDocumento);
            if (paciente != null)
            {
                paciente.fecha_nacimiento_string = paciente.fecha_nacimiento.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            }

            return paciente;
        }
    }
}
