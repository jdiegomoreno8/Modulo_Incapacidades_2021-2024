using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
   public interface IRelacionPacienteAportanteNegocio
    {
        string NuevoRelacionPacienteAportante(RelacionPacienteAportante relacionPacienteAportante);

        IList<RelacionPacienteAportante> Consultar_TodosRelacionPacienteAportante(string id_incapacidad);

    }
}
