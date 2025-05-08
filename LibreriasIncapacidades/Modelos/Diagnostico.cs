using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
    public class Diagnostico
    {
        public Int64 id_diagnosticos { get; set; }
        public string cod_diagnostico { get; set; }
        public string descripcion { get; set; }
        public string version_CIE10 { get; set; }
        public bool habilitado { get; set; }
    }

}
