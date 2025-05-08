using LibreriasIncapacidades.Modelos;
using NegocioIncapacidades;
using ServiciosIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
{
   public class RegimenServicio: IRegimenServicio
    {
        private readonly IRegimenNegocio regimenNegocio;
        public RegimenServicio(IRegimenNegocio RegimenNegocioIn)
        {
            regimenNegocio = RegimenNegocioIn;
        }
        public IEnumerable<Regimen> Consultar_Regimen()
        {
            var ListaRegimen = regimenNegocio.Consultar_Todos_Regimen();
            return ListaRegimen;
        }
    }
}
