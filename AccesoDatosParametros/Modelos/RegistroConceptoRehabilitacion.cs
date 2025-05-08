using System;

namespace LibreriasParametros.Modelos
{
    public class RegistroConceptoRehabilitacion
    {
        public string id_registro_concepto { get; set; }
        public string id_incapacidad { get; set; }
        public string tipo_documento_pac { get; set; }
        public string numero_documento_pac { get; set; }
        public Concepto_Rehabilitacion concepto_rehabilitacion { get; set; }
        //public string concepto_rehabilitacion { get; set; }
        public string numero_concepto { get; set; }
        public string observaciones { get; set; }
        public DateTime fecha_emision { get; set; }
        public DateTime fecha_registro { get; set; }
        public string id_doc_medico_emite { get; set; }
        public string numero_doc_medico_emite { get; set; }
        public string id_entidad_registra { get; set; }
        public string numero_doc_entidad_registra { get; set; }
        public string nombre_entidad_registra { get; set; }
        public string id_doc_medico_registra { get; set; }
        public string numero_doc_medico_registra { get; set; }
        public string nombres_medico_registra { get; set; }
    }
}
