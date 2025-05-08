using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
    public class ConsultaConceptosRehabilitacion
    {
        public int id_registro_concepto { get; set; }
        public string id_incapacidad { get; set; }
        public string tipo_documento_pac { get; set; }
        public string numero_documento_pac { get; set; }
        public int concepto_rehabilitacion { get; set; }
        public DateTime fecha_concepto { get; set; }
        public string numero_concepto { get; set; }
        public string observacion { get; set; }
        public DateTime fecha_registro_concepto { get; set; }
        public string tipo_documento_emite { get; set; }
        public string num_doc_medico_emite { get; set; }
        public string tipo_doc_med_registra { get; set; }
        public string num_doc_medico_registra { get; set; }

        public string nom_apellidos_med_registra { get; set; }
        public string tipo_doc_entidad_registra { get; set; }
        public string num_doc_entidad_registra { get; set; }

        public string nombres_entidad_registra { get; set; }

        public string id_usuario_hercules { get; set; }


    }
}



