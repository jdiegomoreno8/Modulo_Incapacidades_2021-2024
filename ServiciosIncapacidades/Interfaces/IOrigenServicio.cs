using LibreriasIncapacidades.Modelos;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades
{
    public interface IOrigenServicio
    {
        public IEnumerable<Origen> Consultar_Origen();
    }
}
