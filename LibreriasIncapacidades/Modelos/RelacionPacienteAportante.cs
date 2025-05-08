using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
    public class RelacionPacienteAportante
    {
        public  string id_incapacidad { get; set; }
        public string tipo_documento_pac { get; set; }
        public string numero_documento_pac { get; set; }
        public string ultimo_periodo_salud { get; set; }
        public string ultimo_periodo_afp_arl { get; set; }
        public string cod_administradora_eps { get; set; }
        public string cod_administradora_afp { get; set; }
        public string cod_administradora_arl { get; set; }

        public int    IBC { get; set; }
        public string tipo_documento_ap { get; set; }
        public string numero_documento_ap { get; set; }

        public bool relacion_causa_incapacidad { get; set; }

        public string razon_social_descripcion { get; set; }

        public string desc_administradora_arl { get; set; }

        public string desc_administradora_eps { get; set; }


    }
}
