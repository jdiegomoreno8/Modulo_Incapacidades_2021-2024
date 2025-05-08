using System;
using LibreriasParametros.Modelos.General;
using LibreriasParametros.Modelos.Incapacidades;

namespace LibreriasParametros.Modelos
{
    public class Incapacidad
    {
        
        public string id_incapacidad { get; set; }
        public Boolean paciente_encontrado { get; set; }
        public string tipo_documento_pac { get; set; }
        public string numero_documento_pac { get; set; }
        public string primer_nombre_pac { get; set; }
        public string segundo_nombre_pac { get; set; }
        public string primer_apellido_pac { get; set; }
        public string segundo_apellido_pac { get; set; }
        public string sexo_pac { get; set; }
        public int edad_pac { get; set; }
        public string id_tipo_afiliado { get; set; }
        public Boolean proviene_anulado { get; set; }
        public string? id_incapacidad_anulado { get; set; }
        public int id_servicio { get; set; }
        public int id_finalidad { get; set; }
        public int id_modalidad { get; set; }
        public Boolean retroactiva { get; set; }
        public int? id_retroactiva { get; set; }
        public int? id_trastorno_memoria { get; set; }
        public int id_origen { get; set; }
        public int id_causa { get; set; }
        public Int64 diagnostico_principal { get; set; }
        public Int64? diagnostico_relacion_1 { get; set; }
        public Int64? diagnostico_relacion_2 { get; set; }

        public DateTime? fecha_inicio { get; set; }
        public string fecha_inicio_string { get; set; }
        public DateTime? fecha_fin { get; set; }
        public string fecha_fin_string { get; set; }




        public int dias_incapacidad { get; set; }

        public DateTime? fecha_expedicion { get; set; }

        public string fecha_expedicion_string { get; set; }
        public string lugar_expedicion { get; set; }

        public string lugar_expedicion_descripcion { get; set; }

        public Boolean prorroga { get; set; }
        public int dias_acumulados_prorroga { get; set; }

        public Boolean pagada { get; set; }
        public Boolean anulada { get; set; }

        public Boolean acumula_dias_pago { get; set; }
        public int id_usuario_hercules { get; set; }
        public int id_entidad { get; set; }
        public int id_rol { get; set; }

        
        public bool filtroUltimos30dias { get; set; }
        public bool excluirAnuladas { get; set; }


        public TipoDocumento TipoDocumento { get; set; }

        public TipoAfiliado TipoAfiliado { get; set; }

        public Origen Origen { get; set; }
        public CausaAtencion CausaAtencion { get; set; }
        public Diagnostico Diagnostico { get; set; }
        public DiagnosticoRelacionUno DiagnosticoRelacionUno { get; set; }
        public DiagnosticoRelacionDos DiagnosticoRelacionDos { get; set; }

        public GrupoServicios GrupoServicios { get; set; }

        public ModalidadRealizacionConsulta Modalidad{ get; set; }

        public Notificaciones NotificacionRadicacion { get; set; }

        public string medico_nombre { get; set; }
        public string medico_identificacion { get; set; }
        public string medico_entidad { get; set; }

        public string medico_profesion { get; set; }

        public string id_incapacidad_anterior { get; set; }


        public Boolean laboralNoVigente { get; set; }

    }
}
