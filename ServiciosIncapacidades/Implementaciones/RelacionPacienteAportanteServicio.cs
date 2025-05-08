using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades.Interfaces;
using System.Collections.Generic;

namespace ServiciosIncapacidades.Implementaciones
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

        public IEnumerable<RelacionPacienteAportante> Consultar_Relacion_Paciente_Aportante(string id_incapacidad)
        {
            var ListaRelacionPacienteAportante = RelacionPacienteAportanteNegocio.Consultar_TodosRelacionPacienteAportante(id_incapacidad);
            return ListaRelacionPacienteAportante;
        }
    }
}
