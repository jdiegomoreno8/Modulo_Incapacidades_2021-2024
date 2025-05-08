using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
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
