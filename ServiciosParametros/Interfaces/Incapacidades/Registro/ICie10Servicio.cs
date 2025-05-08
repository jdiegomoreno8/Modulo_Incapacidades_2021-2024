using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;

namespace ServiciosParametros.Incapacidades
{
    public interface ICie10Servicio
    {
        public IEnumerable<Cie10> ObtenerCie10();
        public IEnumerable<Cie10> ObtenerCie10(string value);
    }
}
