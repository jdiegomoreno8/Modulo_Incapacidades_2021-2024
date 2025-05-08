using System;
using System.Collections.Generic;
using System.Text;

namespace LibreriasIncapacidades.Modelos
{
    public class RegistrarPago
    {
        public string id_incapacidad { get; set; }
        public DateTime fecha_radicacion { get; set; }
        public int estado_pago { get; set; }
        public int? causal_glosa { get; set; }
        public string nro_autorizacion { get; set; }
        public int? tipo_pago { get; set; }
        public int valor_pagado { get; set; }
        public int dias_pagados { get; set; }
        public int? causal_dias { get; set; }
        public DateTime fecha_pago { get; set; }
        public int ibc_pago { get; set; }
        public string entidad_responsable_pago { get; set; }
        public int id_usuario_hercules { get; set; }
        public int reporte_servicio_web { get; set; }
        public int buscado_pila { get; set; }
        public int ibc_pila { get; set; }
        public int periodo_salud_pila { get; set; }

        public string tipo_documento_aportante { get; set; }

        public string numero_documento_aportante { get; set; }

        //Se agrega fecha de registro del pago incapacidad
        public DateTime fecha_registro_pago { get; set; }
    }
}
