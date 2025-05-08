using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
    public class Aportante
    {
        //public Int64 id_aportante { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        public string razon_social { get; set; }
        public string cod_depto { get; set; }
        public string cod_municipio { get; set; }
        public string direccion { get; set; }
        public string correo_electronico { get; set; }

    }
}
