using System;
using System.Collections.Generic;

namespace LibreriasIncapacidades.Modelos.Integracion
{
    public class MaestroPriorizado
    {

        public string tipo_identificacion { get; set; }
        public string numero_identificacion { get; set; }
        //public Boolean paciente_encontrado { get; set; }
        public string primer_nombre { get; set; }
        public string segundo_nombre { get; set; }
        public string primer_apellido { get; set; }
        public string segundo_apellido { get; set; }

        public DateTime fecha_nacimiento { get; set; }
        
        public string sexo { get; set; }

        public string Codigo_Entidad { get; set; }
        public string Regimen { get; set; }
        
        public string TipoAfiliado { get; set; }
        public int MarcaPVS { get; set; }
        public DateTime? FechaInicioContrato { get; set; }
        public DateTime? FechaFinalContrato { get; set; }
        public int MarcaInpec { get; set; }
        public DateTime? FechaIngresoInpec { get; set; }
        public DateTime? FechaRetiroInpec { get; set; }

        public string estado { get; set; }
        public string departamento_afil { get; set; }
        public string municipio_afil { get; set; }
        public string departamento_res { get; set; }
        public string municipio_res { get; set; }

        public string VersionBDUA { get; set; }
        public string VersionBDEX { get; set; }
        public string VersionINPEC { get; set; }
        public string VersionPVS { get; set; }
        public int estado_consulta { get; set; }

       
    }
}
