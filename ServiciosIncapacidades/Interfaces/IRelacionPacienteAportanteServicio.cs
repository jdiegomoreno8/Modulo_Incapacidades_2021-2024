using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
    public interface IRelacionPacienteAportanteServicio
    {
        public string AdicionarRelacionPacienteAportante(RelacionPacienteAportante relacionPacienteAportante);

        public IEnumerable<RelacionPacienteAportante> Consultar_Relacion_Paciente_Aportante(string id_incapacidad);
    }
}
