using LibreriasParametros.Modelos;
using NegocioParametros;

namespace ServiciosParametros
{
   public class RelacionPacienteAfiliacionSaludServicio : IRelacionPacienteAfiliacionSaludServicio
    {
        private readonly IRelacionPacienteAfiliacionSaludNegocio relacionPacienteAfiliacionSaludNegocio;
        public RelacionPacienteAfiliacionSaludServicio(IRelacionPacienteAfiliacionSaludNegocio relacionPacienteAfiliacionSaludNegocioIn)
        {
            relacionPacienteAfiliacionSaludNegocio = relacionPacienteAfiliacionSaludNegocioIn;
        }

        public string AdicionarRelacionPacienteAfiliacionSalud(RelacionPacienteAfiliacionSalud relacionPacienteAfiliacionSalud)
        {
            return relacionPacienteAfiliacionSaludNegocio.NuevoRelacionPacienteAfiliacionSalud(relacionPacienteAfiliacionSalud);
        }

        public RelacionPacienteAfiliacionSalud ConsultarRelacionPacienteAfiliacionSalud(long idPaciente)
        {
            return relacionPacienteAfiliacionSaludNegocio.ConsultarRelacionPacienteAfiliacionSalud(idPaciente);
        }
    }
}
