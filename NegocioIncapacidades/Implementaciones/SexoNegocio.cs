using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
   public class SexoNegocio : ISexoNegocio
    {
        readonly IAccesoDatosReadOnly sexoRepositorio;

        public SexoNegocio(IAccesoDatosReadOnly sexoRepositorioIn)
        {
            sexoRepositorio = sexoRepositorioIn;
        }
        public IList<Sexo> Consultar_Todos_Sexo()
        {
            return sexoRepositorio.Consultar_Sexo();
        }
    }
}
