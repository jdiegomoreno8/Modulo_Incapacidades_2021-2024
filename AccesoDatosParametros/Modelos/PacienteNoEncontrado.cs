using System;

namespace LibreriasParametros.Modelos
{
    public class PacienteNoEncontrado : Paciente
    {
        public Int64 id_pacienteNoEncontrado { get; set; }
        
        public string cod_depto_afiliacion { get; set; }
        public string cod_mun_afiliacion { get; set; }
        //public string id_regimen { get; set; }
        //public string codigo_eps { get; set; }
        //public string razon_social { get; set; }
        //public string tipo_documento_ap { get; set; }
        //public string numero_documento_ap { get; set; }
        //public string direccion_ap { get; set; }
        //public string correo_electronico { get; set; }
        public Int64? id_incapacidad { get; set; }
        public DateTime? fecha_reporte { get; set; }
        public string fecha_reporte_string { get; set; }

        //public DateTime? fecha_nacimiento { get; set; }
        //public string fecha_nacimiento_string { get; set; }

        //public IList<Aportante> aportantes { get; set; }
        //public RelacionPacienteAfiliacionSalud RelacionPacienteAfiliacionSalud { get; set; }


        public string id_regimen { get; set; }
        public string eps { get; set; }
    }
}
