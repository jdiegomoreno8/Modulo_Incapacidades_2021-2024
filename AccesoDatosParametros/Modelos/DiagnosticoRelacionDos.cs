using System;
using System.Collections.Generic;

namespace LibreriasParametros.Modelos
{
    public class DiagnosticoRelacionDos
    {
        public Int64 id_diagnostico_dos { get; set; }
        public string cod_diag_relacion_dos { get; set; }
        public string descripcion { get; set; }
        public string version_CIE10 { get; set; }
        public bool habilitado { get; set; }
    }

}
