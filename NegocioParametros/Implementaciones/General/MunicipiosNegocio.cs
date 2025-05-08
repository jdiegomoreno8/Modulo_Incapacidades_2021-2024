using LibreriasParametros.AccesoDatos;
using LibreriasParametros.Modelos.General;
using System.Collections.Generic;

namespace NegocioParametros.General
{
  public  class MunicipiosNegocio : IMunicipiosNegocio
    {
        readonly IAccesoDatosReadOnly municipiosRepositorio;
        public MunicipiosNegocio(IAccesoDatosReadOnly municipiosRepositorioIn)
        {
            municipiosRepositorio = municipiosRepositorioIn;
        }
        public IList<Municipios> Consultar_Todos_Municipios()
        {
            //return municipiosRepositorio.Consultar_Municipios();
            return (IList<Municipios>)municipiosRepositorio.Consultar_Municipios();
        }
    }
}
