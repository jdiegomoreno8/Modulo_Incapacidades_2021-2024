using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos;

namespace NegocioParametros
{
   public class PacienteNoEncontradoNegocio : IPacienteNoEncontradoNegocio
    {
        readonly IAccesoDatosDataWrite pacientenoencontradoRepositorio;

        public PacienteNoEncontradoNegocio(IAccesoDatosDataWrite pacientenoencontradoRepositorioIn)
        {
            pacientenoencontradoRepositorio = pacientenoencontradoRepositorioIn;
        }

        public string NuevoPacienteNoEncontrado(PacienteNoEncontrado pacientenoencontrado)
        {
            return pacientenoencontradoRepositorio.InsertarPacienteNoEncontrado(pacientenoencontrado).resultado;
        }
    }
}
