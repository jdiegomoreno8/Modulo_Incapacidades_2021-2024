using System;

namespace LibreriasParametros.Modelos
{
    public class IncapacidadAnulada
    {
        public string id_incapacidad { get; set; }
        public string causa_anulacion { get; set; }
        public string campos_causa { get; set; }
        public string observacion { get; set; }
        public DateTime fecha_anulacion { get; set; }
        public int id_usuario_hercules { get; set; }

    }

}
