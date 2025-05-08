using LibreriasParametros.Modelos;
using NegocioParametros;

namespace ServiciosParametros
{
   public class RelacionPacienteAportanteServicio : IRelacionPacienteAportanteServicio
    {
        private readonly IRelacionPacienteAportanteNegocio RelacionPacienteAportanteNegocio;
        public RelacionPacienteAportanteServicio(IRelacionPacienteAportanteNegocio RelacionPacienteAportanteNegocioIn)
        {
            RelacionPacienteAportanteNegocio = RelacionPacienteAportanteNegocioIn;
        }


        public string AdicionarRelacionPacienteAportante(RelacionPacienteAportante relacionPacienteAportante)
        {
            return RelacionPacienteAportanteNegocio.NuevoRelacionPacienteAportante(relacionPacienteAportante);
        }
    }
}
