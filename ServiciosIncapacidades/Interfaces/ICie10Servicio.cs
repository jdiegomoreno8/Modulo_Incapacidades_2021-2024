using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
    public interface ICie10Servicio
    {
        public IEnumerable<Cie10> ObtenerCie10();
        public IEnumerable<Cie10> ObtenerCie10(string value);
    }
}
