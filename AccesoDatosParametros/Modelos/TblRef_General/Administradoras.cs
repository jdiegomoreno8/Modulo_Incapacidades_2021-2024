using System;

namespace LibreriasParametros.Modelos.General
{
   public class Administradoras
    {
        public string cod_administradora { get; set; }
        public string nit { get; set; }
        public string razon_social { get; set; }
        public Int64 tipo_administradora { get; set; }
        public string cod_regimen { get; set; }
        public int habilitado { get; set; }

        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string correo_electronico { get; set; }
    }
}
