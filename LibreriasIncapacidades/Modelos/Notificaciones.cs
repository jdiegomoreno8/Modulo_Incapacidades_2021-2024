using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
    public class Notificaciones
    {
        public string id_notificacion { get; set; }
        public DateTime? fecha_notificacion { get; set; }

        public string fecha_notificacion_string { get; set; }
        public int id_tipo_notificacion { get; set; }
    }
}
