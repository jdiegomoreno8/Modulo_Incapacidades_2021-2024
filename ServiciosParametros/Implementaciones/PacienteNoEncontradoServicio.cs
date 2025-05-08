using LibreriasParametros.Modelos;
using NegocioParametros;
using System;

namespace ServiciosParametros
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
