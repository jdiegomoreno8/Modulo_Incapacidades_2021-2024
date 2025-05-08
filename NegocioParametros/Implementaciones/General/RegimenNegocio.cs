using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace NegocioParametros.General
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
            //return regimenRepositorio.Consultar_Regimen();
            return (IList<Regimen>)regimenRepositorio.Consultar_Regimen();
        }
    }
}
