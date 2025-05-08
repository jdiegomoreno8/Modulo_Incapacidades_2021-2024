using Dapper;
using LibreriasParametros.Modelos;
using LibreriasParametros.Modelos.General;
using LibreriasParametros.Modelos.Incapacidades;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace LibreriasParametros.AccesoDatos
{
    public class AccesoDatosReadOnly : IAccesoDatosReadOnly
    {
        private readonly IConexionFactory ConexionFactory;
        //private readonly string ConnectionString;

        private readonly IDapperWrapper DapperWrapper;

        public AccesoDatosReadOnly(IConexionFactory conexionFactoryIn, IDapperWrapper dapperWrapper)
        {
            ConexionFactory = conexionFactoryIn;
            //ConnectionString = connectionString;
            DapperWrapper = dapperWrapper;
            //Conexion = new Conexion();
        }

        public IList<GrupoServicios> Consultar_Grupo_Servicios()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var gruposervicios = DapperWrapper.Query<GrupoServicios>(connection, "dbo.Consultar_Grupo_Servicios",
                                    commandType: CommandType.StoredProcedure);
                return gruposervicios.ToList();
            };
        }


        public IList<EstadoPago> Consultar_Estado_Pago()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var estadoPagoServicio = DapperWrapper.Query<EstadoPago>(connection, "dbo.Consultar_Estado_Pago",
                                    commandType: CommandType.StoredProcedure);
                return estadoPagoServicio.ToList();
            };
        }

        public IList<CausalGlosa> Consultar_Causal_Glosa()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var causalGlosaServicios = DapperWrapper.Query<CausalGlosa>(connection, "dbo.Consultar_Causal_Glosa",
                                    commandType: CommandType.StoredProcedure);
                return causalGlosaServicios.ToList();
            };
        }



		public IList<FinalidadConsulta> Consultar_Finalidad_Consulta()
		{
			using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
			{
				var finalidadconsulta = DapperWrapper.Query<FinalidadConsulta>(connection, "dbo.Consultar_Finalidad_Consulta",
									commandType: CommandType.StoredProcedure);
				return finalidadconsulta.ToList();
			};
		}

		public IList<ModalidadRealizacionConsulta> Consultar_Modalidad_Realizacion_Consulta()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var modalidadrealizacionconsultas = DapperWrapper.Query<ModalidadRealizacionConsulta>(connection, "dbo.Consultar_Modalidad_Realizacion_Consulta",
                                    commandType: CommandType.StoredProcedure);
                return modalidadrealizacionconsultas.ToList();
            };
        }



        public IList<Origen> Consultar_Origen()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var origen = DapperWrapper.Query<Origen>(connection, "dbo.Consultar_Origen",
                                    commandType: CommandType.StoredProcedure);
                return origen.ToList();
            };
        }

        public IList<CausaAtencion> Consultar_Causa_Motivo_Atencion()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var causaatencion = DapperWrapper.Query<CausaAtencion>(connection, "dbo.Consultar_Causa_Motivo_Atencion",
                                    commandType: CommandType.StoredProcedure);
                return causaatencion.ToList();
            };
        }

        public IList<TipoDocumento> Consultar_Tipo_Documento()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var tipodocumento = DapperWrapper.Query<TipoDocumento>(connection, "dbo.Consultar_Tipo_Documento",
                                    commandType: CommandType.StoredProcedure);
                return tipodocumento.ToList();
            };
        }

        public IList<TranstornoMental> Consultar_Transtorno_Mental()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var transtornomental = DapperWrapper.Query<TranstornoMental>(connection, "dbo.Consultar_Transtorno_Mental",
                                    commandType: CommandType.StoredProcedure);
                return transtornomental.ToList();
            };
        }

        public IList<MotivaRetroactiva> Consultar_Motiva_Retroactiva()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var motivaretroactiva = DapperWrapper.Query<MotivaRetroactiva>(connection, "dbo.Consultar_Motivo_Retroactividad",
                                    commandType: CommandType.StoredProcedure);
                return motivaretroactiva.ToList();
            };
        }

        public IList<Cie10> ConsultaCie10()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var result = DapperWrapper.Query<Cie10>(connection, "dbo.Consultar_T_CIE10",
                                    commandType: CommandType.StoredProcedure);
                return result.ToList();
            };
        }


        public IList<Cie10> ConsultaCie10(string value)
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var result = DapperWrapper.Query<Cie10>(connection, "dbo.Consultar_T_CIE10", new { parametro=value },
                                    CommandType.StoredProcedure);
                return result.ToList();
            };
        }

        public IList<Municipios> Consultar_Municipios()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var municipios = DapperWrapper.Query<Municipios>(connection, "dbo.Consultar_Municipio",
                                    commandType: CommandType.StoredProcedure);
                return municipios.ToList();
            };
        }

        public IList<Regimen> Consultar_Regimen()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var regimen = DapperWrapper.Query<Regimen>(connection, "dbo.Consultar_Regimen",
                                    commandType: CommandType.StoredProcedure);
                return regimen.ToList();
            };
        }

        public IList<Sexo> Consultar_Sexo()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var sexo = DapperWrapper.Query<Sexo>(connection, "dbo.Consultar_Sexo",
                                    commandType: CommandType.StoredProcedure);
                return sexo.ToList();
            };
        }


        public IList<Departamentos> Consultar_Departamentos()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var departamentos = DapperWrapper.Query<Departamentos>(connection, "dbo.Consultar_Departamento",
                                    commandType: CommandType.StoredProcedure);
                return departamentos.ToList();
            };
        }

        public IList<Incapacidad> Consultar_Incapacidad_Por_Paciente(Incapacidad incapacidad)
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var listaIncapacidades = DapperWrapper.Query<Incapacidad>(connection, "dbo.Consultar_Incapacidad_anterior",
                    new[]
                 {
                    typeof(Incapacidad),
                    typeof(Diagnostico),
                    typeof(DiagnosticoRelacionUno),
                    typeof(DiagnosticoRelacionDos),
                 },
                 objects =>
                 {
                     Incapacidad poi = objects[0] as Incapacidad;
                     Diagnostico t = objects[1] as Diagnostico;
                     DiagnosticoRelacionUno d2 = objects[2] as DiagnosticoRelacionUno;
                     DiagnosticoRelacionDos d3 = objects[3] as DiagnosticoRelacionDos;

                     
                     poi.Diagnostico = t;
                     poi.DiagnosticoRelacionUno = d2;
                     poi.DiagnosticoRelacionDos = d3;

                     return poi;
                 },
                new
                {
                    //filtros
                    tipo_documento_pac = incapacidad.tipo_documento_pac,
                    numero_documento_pac = incapacidad.numero_documento_pac,
                    id_incapacidad = incapacidad.id_incapacidad,
                    id_usuario_hercules = incapacidad.id_usuario_hercules,
                    filtroUltimos30dias = incapacidad.filtroUltimos30dias,
                    excluirAnuladas = incapacidad.excluirAnuladas
                },
                splitOn: "id_diagnosticos, id_diagnosticos, id_diagnosticos",
                commandType: CommandType.StoredProcedure);


                return listaIncapacidades.ToList();
            };
        }

        public IList<Incapacidad> Consultar_Incapacidad_Concepto_Rehabilitacion(Paciente paciente)
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var listaIncapacidades = DapperWrapper.Query<Incapacidad>(connection, "dbo.Consultar_Incapacidad_Concepto_Rehabilitacion",
                 new[]
                 {
                    typeof(Incapacidad),
                    typeof(TipoDocumento),
                    typeof(TipoAfiliado),
                    typeof(GrupoServicios),
                    typeof(Origen),
                    typeof(CausaAtencion),
                    typeof(Diagnostico),
                    typeof(DiagnosticoRelacionUno),
                    typeof(DiagnosticoRelacionDos),
                    typeof(ModalidadRealizacionConsulta),
                 },
                 objects =>
                 {
                     Incapacidad poi = objects[0] as Incapacidad;
                     TipoDocumento ps = objects[1] as TipoDocumento;
                     TipoAfiliado pt = objects[2] as TipoAfiliado;
                     GrupoServicios pc = objects[3] as GrupoServicios;
                     Origen l = objects[4] as Origen;
                     CausaAtencion c = objects[5] as CausaAtencion;
                     Diagnostico t = objects[6] as Diagnostico;
                     DiagnosticoRelacionUno d2 = objects[7] as DiagnosticoRelacionUno;
                     DiagnosticoRelacionDos d3 = objects[8] as DiagnosticoRelacionDos;
                     ModalidadRealizacionConsulta md = objects[9] as ModalidadRealizacionConsulta;

                     poi.TipoDocumento = ps;
                     poi.TipoAfiliado = pt;
                     poi.GrupoServicios = pc;
                     poi.Origen = l;
                     poi.CausaAtencion = c;
                     poi.Diagnostico = t;
                     poi.DiagnosticoRelacionUno = d2;
                     poi.DiagnosticoRelacionDos = d3;
                     poi.Modalidad = md;

                     return poi;
                 },
                new

                {
                    //filtros
                    tipo_documento_pac = paciente.tipo_documento,
                    numero_documento_pac = paciente.numero_documento,
                },
                splitOn: "cod_tipo_documento, id_tipo_afiliado, id_servicio, id_origen, id_causa, id_diagnosticos, id_diagnostico_uno, id_diagnostico_dos, id_modalidad",
                commandType: CommandType.StoredProcedure);


                return listaIncapacidades.ToList();
            }
        }

        public Incapacidad ConsultaIncapacidad(string numeroIncapacidad, string tipoDocumento, string numeroDocumento)
        {

            Incapacidad incapacidad = new Incapacidad();

            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {

                var data = connection.Query<Incapacidad>("dbo.spConsultarIncapacidad",
                 new[]
                 {
                    typeof(Incapacidad),
                    typeof(TipoDocumento),
                    typeof(TipoAfiliado),
                    typeof(GrupoServicios),
                    typeof(Origen),
                    typeof(CausaAtencion),
                    typeof(Diagnostico),
                    typeof(DiagnosticoRelacionUno),
                    typeof(DiagnosticoRelacionDos),
                    typeof(ModalidadRealizacionConsulta),
                    typeof(Notificaciones),
                 },
                 objects =>
                 {
                     Incapacidad poi = objects[0] as Incapacidad;
                     TipoDocumento ps = objects[1] as TipoDocumento;
                     TipoAfiliado pt = objects[2] as TipoAfiliado;
                     GrupoServicios pc = objects[3] as GrupoServicios;
                     Origen l = objects[4] as Origen;
                     CausaAtencion c = objects[5] as CausaAtencion;
                     Diagnostico t = objects[6] as Diagnostico;
                     DiagnosticoRelacionUno d2 = objects[7] as DiagnosticoRelacionUno;
                     DiagnosticoRelacionDos d3 = objects[8] as DiagnosticoRelacionDos;
                     ModalidadRealizacionConsulta md = objects[9] as ModalidadRealizacionConsulta;
                     Notificaciones nt = objects[10] as Notificaciones;

                     poi.TipoDocumento = ps;
                     poi.TipoAfiliado = pt;
                     poi.GrupoServicios = pc;
                     poi.Origen = l;
                     poi.CausaAtencion = c;
                     poi.Diagnostico = t;
                     poi.DiagnosticoRelacionUno = d2;
                     poi.DiagnosticoRelacionDos = d3;
                     poi.Modalidad = md;
                     poi.NotificacionRadicacion = nt;

                     return poi;
                 },
                new
                {
                    IdIncapacidad = numeroIncapacidad,
                    tipoDocumento = tipoDocumento,
                    numeroDocumento = numeroDocumento,
                },
                    splitOn: "cod_tipo_documento, id_tipo_afiliado, id_servicio, id_origen, id_causa, id_diagnosticos, id_diagnostico_uno, id_diagnostico_dos, id_modalidad, id_notificacion",
                    commandType: CommandType.StoredProcedure);
                incapacidad = data.FirstOrDefault();
                return incapacidad;

            }
        }

        public IList<CausaAnulacion> Consultar_Causa_Anulacion()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var causaanulacion = DapperWrapper.Query<CausaAnulacion>(connection, "dbo.Consultar_Causa_Anulacion",
                                    commandType: CommandType.StoredProcedure);
                return causaanulacion.ToList();
            };
        }

        public IList<Administradoras> Consultar_Administradora(string codRegimen, string tipoAdministradora)
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var administradoras = DapperWrapper.Query<Administradoras>(connection, "dbo.Consultar_Administradora", new { codRegimen = codRegimen, tipoAdministradora = tipoAdministradora }, CommandType.StoredProcedure);
                return administradoras.ToList();          };
        }



        public IList<CausalDias> Consultar_Causal_Dias()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var causalDias = DapperWrapper.Query<CausalDias>(connection, "dbo.Consultar_Causal_Dias", CommandType.StoredProcedure);
                return causalDias.ToList();
            };
        }


        public IList<TipoPago> Consultar_Tipo_Pago()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var tipoPago = DapperWrapper.Query<TipoPago>(connection, "dbo.Consultar_Tipo_Pago",
                                    commandType: CommandType.StoredProcedure);
                return tipoPago.ToList();
            };
        }


        public IList<string> Consultar_Campos_Anulacion(string numeroIncapacidad)
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var camposAnulados = connection.Query<string>("dbo.Consultar_Campos_Anulacion",
                new
                {
                    IdIncapacidad = numeroIncapacidad
                },
                commandType: CommandType.StoredProcedure);
                return camposAnulados.ToList();
            };
        }

        public Paciente ObtenerPaciente(string IdTipoDocumento, string NumeroDocumento, string NumeroIncapacidad)
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var paciente = connection.Query<Paciente, Aportante, Paciente>("dbo.Consultar_Paciente",
                    map: (paciente, aportante) =>
                    {
                        paciente.aportanteSeleccionado = aportante;
                        return paciente;
                    },
                    param: new { IdTipoDocumento, NumeroDocumento, NumeroIncapacidad },
                    splitOn: "numero_documento, numero_documento_ap",
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                return paciente;
            };
        }

        public PacienteNoEncontrado ObtenerPacienteNoEncontrado(string IdTipoDocumento, string NumeroDocumento)
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var paciente = connection.Query<PacienteNoEncontrado>("dbo.Consultar_PacienteNoEncontrado",
                    new
                    {
                        @tipo_documento_pac = IdTipoDocumento,
                        @numero_documento_pac = NumeroDocumento
                    },
                    commandType: CommandType.StoredProcedure).FirstOrDefault();

                return paciente;
            };
        }
        public string Consultar_Incapacidad_Registrar_Pago(ConsultarRegistroPago consultarRegistroPago)
        {
            var registrarPago = "dbo.Consultar_Incapacidad_Registrar_Pago";

            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))

            {

                var parametros = new DynamicParameters();
                parametros.Add("id_incapacidad", consultarRegistroPago.id_incapacidad);
                parametros.Add("tipo_documento_pac", consultarRegistroPago.tipo_documento_pac);
                parametros.Add("numero_documento_pac", consultarRegistroPago.numero_documento_pac);
                parametros.Add("estado", dbType: DbType.String, direction: ParameterDirection.Output, size: 2);
                connection.Execute(registrarPago, parametros, commandType: CommandType.StoredProcedure);

                //string estadoConsulta = parametros.Get<object>("estado");
                //return estadoConsulta;

                string estadoConsultaPago = parametros.Get<string>("estado");
                return estadoConsultaPago;

            };

        }






        public RelacionPacienteAfiliacionSalud Consultar_RelacionPacienteAfiliacionSalud(long idPaciente)
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var relacionPacienteAfiliacionSalud = DapperWrapper.Query<RelacionPacienteAfiliacionSalud>(connection, "dbo.Consultar_RelacionPacienteAfiliacionSalud", new { parametro = idPaciente }, CommandType.StoredProcedure);
                if(relacionPacienteAfiliacionSalud.Count() > 0)
                {
                    return relacionPacienteAfiliacionSalud.First();
                }
                return null;
            };
        }

        public IList<Concepto_Rehabilitacion> Consultar_Concepto_Rehabilitacion()
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var regimen = DapperWrapper.Query<Concepto_Rehabilitacion>(connection, "dbo.Consultar_Concepto_Rehabilitacion",
                                    commandType: CommandType.StoredProcedure);
                return regimen.ToList();
            };
        }

        public RegistroConceptoRehabilitacion Consultar_Concepto_Rehabilitacion_Por_Paciente(Paciente pacienteCR)
        {
            using (var connection = ConexionFactory.CrearConexion(EnumConexion.ReadOnly))
            {
                var conceptoRehabilitacion = connection.Query<RegistroConceptoRehabilitacion, Concepto_Rehabilitacion, RegistroConceptoRehabilitacion>("dbo.Consultar_Concepto_Rehabilitacion_Paciente",
                    map: (registroCR, concepto) =>
                    {
                        registroCR.concepto_rehabilitacion = concepto;
                        return registroCR;
                    },
                    param: new {
                        @tipo_documento_pac = pacienteCR.tipo_documento,
                        @numero_documento_pac = pacienteCR.numero_documento
                    },
                    splitOn: "concepto_rehabilitacion",
                    commandType: CommandType.StoredProcedure).FirstOrDefault();


                return conceptoRehabilitacion;
            };
        }

    }
}
