using System;
using System.Collections.Generic;

namespace LibreriasParametros.Modelos
{
    public class Paciente
    {

        public Int64 id_paciente { get; set; }
        public string tipo_documento { get; set; }
        public string numero_documento { get; set; }
        //public Boolean paciente_encontrado { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }
        public string sexo { get; set; }

        public DateTime? fecha_nacimiento { get; set; }

        public string fecha_nacimiento_string { get; set; }

        //public string cod_depto_residencia { get; set; }
        //public string cod_mun_residencia { get; set; }
        //public string id_regimen { get; set; }
        //public string eps { get; set; }

        //public DateTime? fecha_registro { get; set; }
        //public string fecha_registro_string { get; set; }

        public string cod_depto_residencia { get; set; }
        public string cod_mun_residencia { get; set; }

        public DateTime? fecha_registro { get; set; }
        public string fecha_registro_string { get; set; }


        public RelacionPacienteAfiliacionSalud relacionPacienteAfiliacionSalud { get; set; }

        public IList<Aportante> aportantes { get; set; }

        public Aportante aportanteSeleccionado { get; set; }

        public IList<RelacionPacienteAportante> relacionesPacienteAportante { get; set; }

        public RelacionPacienteAportante relacionPacienteAportanteSeleccionada { get; set; }


        public string info_consulta { get; set; }

        public string numeroCertificadoDefuncion { get; set; }

    }
}
