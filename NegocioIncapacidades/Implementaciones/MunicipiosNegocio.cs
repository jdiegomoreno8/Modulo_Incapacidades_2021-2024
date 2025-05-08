using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace NegocioIncapacidades
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
            return municipiosRepositorio.Consultar_Municipios();
        }
    }
}
