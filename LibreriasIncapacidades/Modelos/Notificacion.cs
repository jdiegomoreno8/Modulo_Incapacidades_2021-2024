using System;

namespace LibreriasIncapacidades.Modelos
{
    public class Notificacion
    {

        public Int64 id_notificacion { get; set; }
        public int id_tipo_notificacion { get; set; }
        public DateTime fecha_notificacion { get; set; }
        public string correo_destinatario { get; set; }
        public string id_entidad_destino { get; set; }
        public int id_tipo_proceso { get; set; }
        public string id_proceso { get; set; }
        public int estado { get; set; }


    }
}
