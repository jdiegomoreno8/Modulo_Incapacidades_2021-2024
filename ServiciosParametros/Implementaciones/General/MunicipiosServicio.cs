using LibreriasParametros.Modelos.General;
using System.Collections.Generic;
using NegocioParametros.General;

namespace ServiciosParametros.General
{
   public class MunicipiosServicio: IMunicipiosServicio
    {
        private readonly IMunicipiosNegocio municipiosNegocio;
        public MunicipiosServicio(IMunicipiosNegocio MunicipiosNegocioIn)
        {
            municipiosNegocio = MunicipiosNegocioIn;
        }
        public IEnumerable<Municipios> Consultar_Municipios()
        {
            var ListaMunicipios = municipiosNegocio.Consultar_Todos_Municipios();
            return ListaMunicipios;
        }
    }
}
