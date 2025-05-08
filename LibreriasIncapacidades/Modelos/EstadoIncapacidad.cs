using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
    class EstadoIncapacidad
    {
        public int id_estado_incapacidad { get; set; }
        public string descripcion { get; set; }
        public Boolean habilitado { get; set; }
    }
}
