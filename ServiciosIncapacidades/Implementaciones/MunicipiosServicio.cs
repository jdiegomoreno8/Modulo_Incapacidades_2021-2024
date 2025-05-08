using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
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
