using LibreriasParametros.Modelos;
using NegocioParametros;
using System;

namespace ServiciosParametros
{
    public class PacienteServicio: IPacienteServicio
    {
        private readonly IPacienteNegocio pacienteNegocio;
        public PacienteServicio(IPacienteNegocio pacienteNegocioIn)
        {
            pacienteNegocio = pacienteNegocioIn;
        }

        public Paciente AdicionarPaciente(Paciente pacientes)
        {
            pacientes.id_paciente = Int64.Parse(pacienteNegocio.NuevoPaciente(pacientes));
            return pacientes;
        }

        public Paciente ConsultarPaciente(string idTipoDocumento, string numeroDocumento, string numeroIncapacidad)
        {
            var paciente = pacienteNegocio.ObtenerPaciente(idTipoDocumento, numeroDocumento, numeroIncapacidad);
            return paciente;
        }

        public PacienteNoEncontrado ConsultarPacienteNoEncontrado(string idTipoDocumento, string numeroDocumento)
        {
            var paciente = pacienteNegocio.ObtenerPacienteNoEncontrado(idTipoDocumento, numeroDocumento);
            return paciente;
        }
    }
}
