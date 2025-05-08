using LibreriasParametros.Modelos.General;
using System.Collections.Generic;
using NegocioParametros.General;

namespace ServiciosParametros.General
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
