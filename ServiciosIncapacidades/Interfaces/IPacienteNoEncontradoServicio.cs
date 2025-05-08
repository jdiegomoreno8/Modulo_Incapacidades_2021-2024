using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Interfaces
{
    public interface IPacienteNoEncontradoServicio
    {
        public PacienteNoEncontrado AdicionarPacienteNoEncontrado(PacienteNoEncontrado pacientenoencontrado);
    }
}
