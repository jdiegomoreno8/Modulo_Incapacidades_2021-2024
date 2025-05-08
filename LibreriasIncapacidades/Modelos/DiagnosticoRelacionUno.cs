using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
    public class DiagnosticoRelacionUno
    {
        public Int64 id_diagnostico_uno { get; set; }
        public string cod_diag_relacion_uno { get; set; }
        public string descripcion { get; set; }
        public string version_CIE10 { get; set; }
        public bool habilitado { get; set; }
    }

}
