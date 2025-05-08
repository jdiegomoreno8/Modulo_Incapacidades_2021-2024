using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
{
  public  class PacienteNoEncontradoServicio: IPacienteNoEncontradoServicio
    {
        private readonly IPacienteNoEncontradoNegocio PacienteNoEncontradoNegocio;
        public PacienteNoEncontradoServicio(IPacienteNoEncontradoNegocio PacienteNoEncontradoNegocioIn)
        {
            PacienteNoEncontradoNegocio = PacienteNoEncontradoNegocioIn;
        }

        public PacienteNoEncontrado AdicionarPacienteNoEncontrado(PacienteNoEncontrado pacientenoencontrado)
        {
            pacientenoencontrado.id_pacienteNoEncontrado = Int64.Parse(PacienteNoEncontradoNegocio.NuevoPacienteNoEncontrado(pacientenoencontrado));
            return pacientenoencontrado;
        }

    }
}
