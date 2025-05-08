using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
    public class PerdidaCapacidadLaboral
    {
        public Int64 id_concepto_registro { get; set; }
		public string numero_registro { get; set; }

        public int id_origen { get; set; }
        public int porcentaje_perdida_capacidad_laboral { get; set; }
        public	DateTime fecha_registro_calificacion { get; set; }
        public DateTime fecha_calid_incapacidadificacion_PCL { get; set; }
        public DateTime fecha_estructuracion { get; set; }
        public int nueva_calificacion { get; set; }
        public string observaciones { get; set; }
        public int tipo_profesional { get; set; }

        public string despacho_autoridad_judicial { get; set; }
        public string nombres_apellidos_juez { get; set; }


        public string tipo_documento_entidad { get; set; }
        public string numero_documento_entidad { get; set; }
        public string nombre_razon_social { get; set; }

        public string tipo_documento_emite { get; set; }
        public string numero_documento_emite { get; set; }
        public string nombre_profesional_emite { get; set; }

        public string diagnostico_principal { get; set; }
        public string diagnostico_relacion_1 { get; set; }
        public string diagnostico_relacion_2 { get; set; }
        //public string tipo_documento_entidad_profesional { get; set; }
        //public string numero_documento_entidad_profesional { get; set; }
        //public string nombre_razon_social_profesional { get; set; }



    }
}
