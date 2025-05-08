using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
    public interface  IConsultaConceptoRehabilitacionServicio
    {
       
        public IEnumerable<RegistroConceptoRehabilitacion> Consultar_ListasConceptosRehabilitacion(Paciente pacienteCR);
    }
}
