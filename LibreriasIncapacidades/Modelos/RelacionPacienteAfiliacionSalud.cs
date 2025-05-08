using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
    public class RelacionPacienteAfiliacionSalud
    {

        public string id_incapacidad { get; set; }
        public Int64 id_paciente { get; set; }
        public string codigo_eps { get; set; }     
        public string tipo_afiliado { get; set; }
        public string estado { get; set; }
        public string regimen { get; set; }
        public string departamento_afil  { get; set; }
        public string municipio_afil { get; set; }

        public int afiliado_PVS { get; set; }
        public DateTime? fecha_inicio_contrato { get; set; }

        public DateTime? fecha_fin_contrato { get; set; }
        public int afiliado_INPEC { get; set; }
        public DateTime? fecha_ingreso_inpec { get; set; }
        public DateTime? fecha_retiro_inpec { get; set; }

        }
}
