using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
    public interface IOrigenServicio
    {
        public IEnumerable<Origen> Consultar_Origen();
    }
}
