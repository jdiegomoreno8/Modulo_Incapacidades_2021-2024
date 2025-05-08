using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
{
  public  class RegimenNegocio : IRegimenNegocio
    {
        readonly IAccesoDatosReadOnly regimenRepositorio;

        public RegimenNegocio(IAccesoDatosReadOnly regimenRepositorioIn)
        {
            regimenRepositorio = regimenRepositorioIn;
        }
        public IList<Regimen> Consultar_Todos_Regimen()
        {
            return regimenRepositorio.Consultar_Regimen();
        }
    }
}
