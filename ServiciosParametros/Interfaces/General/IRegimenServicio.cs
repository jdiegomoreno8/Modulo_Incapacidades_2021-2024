using LibreriasParametros.Modelos.General;
using System.Collections.Generic;


namespace ServiciosParametros.General
{
    public interface IRegimenServicio
    {
        public IEnumerable<Regimen> Consultar_Regimen();
    }
}
