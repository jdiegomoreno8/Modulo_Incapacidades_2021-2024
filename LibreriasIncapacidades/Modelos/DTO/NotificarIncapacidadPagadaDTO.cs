using System;

namespace LibreriasIncapacidades.Modelos.DTO
{
    public class NotificarIncapacidadPagadaDTO
    {
        public string id_incapacidad { get; set; }
        public int id_origen { get; set; }
        public bool paciente_encontrado { get; set; }

        public string origen { get; set; }
        public string tipo_doc_paciente { get; set; }
        public string num_doc_paciente { get; set; }
        public string primer_nom_pac { get; set; }
        public string segundo_nom_pac { get; set; }
        public string primer_ap_pac { get; set; }
        public string segundo_ap_pac { get; set; }
        public DateTime fecha_inicio { get; set; }
        public DateTime fecha_fin { get; set; }
        public int dias_incapacidad { get; set; }

        public DateTime fecha_expedicion { get; set; }

        public string administradora { get; set; }
        public string codigo_administradora { get; set; }
        public string correo_administradora { get; set; }

        public string Aportante { get; set; }
        public string codigo_aportante { get; set; }
        public string correo_aportante { get; set; }    

        public string codigo_regimen { get; set; }

        public DateTime fecha_pago { get; set; }
        public double valor_pagado { get; set; }
    }
}
