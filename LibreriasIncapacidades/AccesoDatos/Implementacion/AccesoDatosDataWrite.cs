using LibreriasIncapacidades.Modelos;
using System;
using System.Data;
using System.Globalization;
using System.Linq;
using WebApiIncapacidades.Modelos.DTO;

namespace LibreriasIncapacidades.AccesoDatos
{
    public class AccesoDatosDataWrite : IAccesoDatosDataWrite
    {
        //private readonly IConexion Conexion;
        //private readonly string ConnectionString;
        private readonly IConexionFactory ConexionFactory;

        private readonly IDapperWrapper DapperWrapper;

        public AccesoDatosDataWrite(IConexionFactory ConexionFactoryIn, IDapperWrapper dapperWrapper)
        {
            ConexionFactory = ConexionFactoryIn;
            //ConnectionString = connectionString;
            DapperWrapper = dapperWrapper;
            //Conexion = new Conexion();
        }

        public RespuestBD InsertarIncapacidad(Incapacidad incapacidad)
        {
            object dataObject = new { };
            try
            {
                using var connection = ConexionFactory.CrearConexion(EnumConexion.Write);
                var result = DapperWrapper.Query<RespuestBD>(connection, "dbo.Insertar_Incapacidad", dataObject = new
                {
                    paciente_encontrado = incapacidad.paciente_encontrado,
                    tipo_documento_pac = incapacidad.tipo_documento_pac,
                    numero_documento_pac = incapacidad.numero_documento_pac,

                    primer_nombre_pac = incapacidad.primer_nombre_pac,
                    segundo_nombre_pac = incapacidad.segundo_nombre_pac,
                    primer_apellido_pac = incapacidad.primer_apellido_pac,
                    segundo_apellido_pac = incapacidad.segundo_apellido_pac,
                    sexo_pac = incapacidad.sexo_pac,

                    //@fecha_nacimiento_pac = null,???
                    id_tipo_afiliado = incapacidad.id_tipo_afiliado,
                    proviene_anulado = incapacidad.proviene_anulado,
                    id_incapacidad_anulado = incapacidad.id_incapacidad_anulado,

                    id_servicio = incapacidad.id_servicio,
                    id_finalidad = incapacidad.id_finalidad,
                    id_modalidad = incapacidad.id_modalidad,
                    retroactiva = incapacidad.retroactiva,
                    id_retroactiva = incapacidad.id_retroactiva,
                    id_trastorno_memoria = incapacidad.id_trastorno_memoria,
                    id_origen = incapacidad.id_origen,
                    id_causa = incapacidad.id_causa,


                    diagnostico_principal = incapacidad.diagnostico_principal,
                    diagnostico_relacion_1 = incapacidad.diagnostico_relacion_1,
                    diagnostico_relacion_2 = incapacidad.diagnostico_relacion_2,

                    fecha_inicio = DateTime.ParseExact(incapacidad.fecha_inicio_string, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    fecha_fin = DateTime.ParseExact(incapacidad.fecha_fin_string, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    dias_incapacidad = incapacidad.dias_incapacidad,

                    fecha_expedicion = incapacidad.fecha_expedicion,//DateTime.ParseExact(incapacidad.fecha_expedicion_string, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture),
                    fecha_registro = DateTime.Now,
                    lugar_expedicion = incapacidad.lugar_expedicion,

                    prorroga = incapacidad.prorroga,
                    dias_acumulados_prorroga = incapacidad.dias_acumulados_prorroga,
                    acumula_dias_pago = incapacidad.acumula_dias_pago,
                    pagada = incapacidad.pagada,
                    anulada = incapacidad.anulada,

                    id_usuario_hercules = incapacidad.id_usuario_hercules,
                    id_entidad = incapacidad.id_entidad,
                    id_rol = incapacidad.id_rol,
                    id_incapacidad_anterior = incapacidad.id_incapacidad_anterior,

                    laboralNoVigente = incapacidad.laboralNoVigente
                },
                commandType: CommandType.StoredProcedure);

                if (!string.IsNullOrWhiteSpace(result.ToList().FirstOrDefault().error))
                {
                    throw new Exception("Error en acceso a datos: " + result.ToList().FirstOrDefault().error);
                }

                return result.ToList().FirstOrDefault();

            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] { dataObject.ToString() });
            }
        }

        public RespuestBD InsertarPaciente(Paciente pacientes)
        {
            object dataObject = new { };
            try
            {
                using var connection = ConexionFactory.CrearConexion(EnumConexion.Write);
                var result = DapperWrapper.Query<RespuestBD>(connection, "dbo.Insertar_Paciente", dataObject = new
                {
                    //paciente_encontrado = pacientes.paciente_encontrado,
                    tipo_documento = pacientes.tipo_documento,
                    numero_documento = pacientes.numero_documento,

                    primer_nombre = pacientes.primer_nombre,
                    segundo_nombre = pacientes.segundo_nombre,
                    primer_apellido = pacientes.primer_apellido,
                    segundo_apellido = pacientes.segundo_apellido,
                    sexo = pacientes.sexo,

                    //fecha_nacimiento = DateTime.ParseExact(pacientes.fecha_nacimiento_string, "yyyy-MM-dd", CultureInfo.InvariantCulture),

                    cod_depto_residencia = pacientes.cod_depto_residencia,
                    cod_mun_residencia = pacientes.cod_mun_residencia,
                    //fecha_registro = pacientes.fecha_registro,
                    //id_regimen = pacientes.id_regimen,
                    //eps = pacientes.eps,


                },
                commandType: CommandType.StoredProcedure);

                if (!string.IsNullOrWhiteSpace(result.ToList().FirstOrDefault().error))
                {
                    throw new Exception("Error en acceso a datos: " + result.ToList().FirstOrDefault().error);
                }

                return result.ToList().FirstOrDefault();
            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] { dataObject.ToString() });
            }
        }


        public RespuestBD InsertarIncapacidadPerdidaCapacidadLaboral(PerdidaCapacidadLaboral incapacidadPerdidaCapacidadLaboral)
        {
            object dataObject = new { };
            try
            {
                using var connection = ConexionFactory.CrearConexion(EnumConexion.Write);
                var result = DapperWrapper.Query<RespuestBD>(connection, "dbo.Insertar_Perdida_Capacidad_Laboral", dataObject = new
                {
                    numero_registro = incapacidadPerdidaCapacidadLaboral.numero_registro,
                    id_origen = incapacidadPerdidaCapacidadLaboral.id_origen,
                    id_concepto_registro = incapacidadPerdidaCapacidadLaboral.id_concepto_registro,
                    porcentaje_perdida_capacidad_laboral = incapacidadPerdidaCapacidadLaboral.porcentaje_perdida_capacidad_laboral,

                    fecha_registro_calificacion = incapacidadPerdidaCapacidadLaboral.fecha_registro_calificacion,
                    fecha_calid_incapacidadificacion_PCL = incapacidadPerdidaCapacidadLaboral.fecha_calid_incapacidadificacion_PCL,
                    fecha_estructuracion = incapacidadPerdidaCapacidadLaboral.fecha_estructuracion,
                    nueva_calificacion = incapacidadPerdidaCapacidadLaboral.nueva_calificacion,
                    observaciones = incapacidadPerdidaCapacidadLaboral.observaciones,                
                    tipo_profesional = incapacidadPerdidaCapacidadLaboral.tipo_profesional,
                    tipo_documento_emite = incapacidadPerdidaCapacidadLaboral.tipo_documento_emite,
                    numero_documento_emite = incapacidadPerdidaCapacidadLaboral.numero_documento_emite,

                    despacho_autoridad_judicial = incapacidadPerdidaCapacidadLaboral.despacho_autoridad_judicial,
                    nombres_apellidos_juez = incapacidadPerdidaCapacidadLaboral.nombres_apellidos_juez,

                    tipo_documento_entidad = incapacidadPerdidaCapacidadLaboral.tipo_documento_entidad,
                    numero_documento_entidad = incapacidadPerdidaCapacidadLaboral.numero_documento_entidad,
                    nombre_razon_social = incapacidadPerdidaCapacidadLaboral.nombre_razon_social
                  

                },
                commandType: CommandType.StoredProcedure);

                if (!string.IsNullOrWhiteSpace(result.ToList().FirstOrDefault().error))
                {
                    throw new Exception("Error en acceso a datos: " + result.ToList().FirstOrDefault().error);
                }

                return result.ToList().FirstOrDefault();

            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] { dataObject.ToString() });
            }
        }


        public RespuestBD InsertarRegistrarPago(RegistrarPago registrarPago)
        {
            object dataObject = new { };
            try
            {
                using (var connection = ConexionFactory.CrearConexion(EnumConexion.Write))
                {
                    dataObject = new
                    {
                        id_incapacidad = registrarPago.id_incapacidad,
                        fecha_radicacion = registrarPago.fecha_radicacion,
                        estado_pago = registrarPago.estado_pago,
                        causal_glosa = registrarPago.causal_glosa,
                        nro_autorizacion = registrarPago.nro_autorizacion,
                        tipo_pago = registrarPago.tipo_pago,
                        valor_pagado = registrarPago.valor_pagado,
                        dias_pagados = registrarPago.dias_pagados,
                        causal_dias = registrarPago.causal_dias,
                        fecha_pago = registrarPago.fecha_pago,
                        ibc_pago = registrarPago.ibc_pago,
                        entidad_responsable_pago = registrarPago.entidad_responsable_pago,
                        id_usuario_hercules = registrarPago.id_usuario_hercules,
                        tipo_documento_aportante = registrarPago.tipo_documento_aportante,
                        numero_documento_aportante = registrarPago.numero_documento_aportante,
                        //Se agrega fecha registro pago
                        //fecha_registro_pago = registrarPago.fecha_registro_pago

                    };

                    var result = DapperWrapper.Query<RespuestBD>(connection, "dbo.Insertar_Registro_Pago", dataObject,
                    commandType: CommandType.StoredProcedure);

                    if (!string.IsNullOrWhiteSpace(result.ToList().FirstOrDefault().error))
                    {
                        throw new Exception("Error en acceso a datos: " + result.ToList().FirstOrDefault().error);
                    }

                    return result.ToList().FirstOrDefault();

                }
            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] { dataObject.ToString() });
            }
        }

        public RespuestBD InsertarRelacionPacienteAportante(RelacionPacienteAportante relacionPacienteAportante)
        {
            object dataObject = new { };
            try
            {
                using (var connection = ConexionFactory.CrearConexion(EnumConexion.Write))
                {
                    var result = DapperWrapper.Query<RespuestBD>(connection, "dbo.Insertar_Relacion_Aportante", dataObject = new
                    {
                        id_incapacidad = relacionPacienteAportante.id_incapacidad,
                        tipo_documento_pac = relacionPacienteAportante.tipo_documento_pac,
                        numero_documento_pac = relacionPacienteAportante.numero_documento_pac,
                        ultimo_periodo_salud = relacionPacienteAportante.ultimo_periodo_salud,
                        ultimo_periodo_afp_arl = relacionPacienteAportante.ultimo_periodo_afp_arl,
                        cod_administradora_eps = relacionPacienteAportante.cod_administradora_eps,
                        cod_administradora_arl = relacionPacienteAportante.cod_administradora_arl,
                        cod_administradora_afp = relacionPacienteAportante.cod_administradora_afp,
                        IBC = relacionPacienteAportante.IBC,
                        tipo_documento_ap = relacionPacienteAportante.tipo_documento_ap,
                        numero_documento_ap = relacionPacienteAportante.numero_documento_ap,


                    },
                    commandType: CommandType.StoredProcedure);

                    if (!string.IsNullOrWhiteSpace(result.ToList().FirstOrDefault().error))
                    {
                        throw new Exception("Error en acceso a datos: " + result.ToList().FirstOrDefault().error);
                    }

                    return result.ToList().FirstOrDefault();

                }

            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] { dataObject.ToString() });
            }
        }

        public RespuestBD InsertarPacienteNoEncontrado(PacienteNoEncontrado pacientenoencontrado)
        {
            object dataObject = new { };
            try
            {
                using var connection = ConexionFactory.CrearConexion(EnumConexion.Write);
                var result = DapperWrapper.Query<RespuestBD>(connection, "dbo.Insertar_PacienteNoEncontrado", dataObject = new
                {
                    //paciente_encontrado = pacientes.paciente_encontrado,
                    tipo_documento = pacientenoencontrado.tipo_documento,
                    numero_documento = pacientenoencontrado.numero_documento,
                    primer_nombre = pacientenoencontrado.primer_nombre,
                    segundo_nombre = pacientenoencontrado.segundo_nombre,
                    primer_apellido = pacientenoencontrado.primer_apellido,
                    segundo_apellido = pacientenoencontrado.segundo_apellido,
                    sexo = pacientenoencontrado.sexo,
                    fecha_nacimiento = pacientenoencontrado.fecha_nacimiento,//DateTime.ParseExact(pacientenoencontrado.fecha_nacimiento_string, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    cod_depto_residencia = pacientenoencontrado.cod_depto_residencia,
                    cod_mun_residencia = pacientenoencontrado.cod_mun_residencia,
                    cod_depto_afiliacion = pacientenoencontrado.cod_depto_afiliacion,
                    cod_mun_afiliacion = pacientenoencontrado.cod_mun_afiliacion,
                    id_regimen = pacientenoencontrado.id_regimen,
                    eps = pacientenoencontrado.eps,



                    //codigo_eps = pacientenoencontrado.codigo_eps,
                    //razon_social = pacientenoencontrado.razon_social,
                    //tipo_documento_ap = pacientenoencontrado.tipo_documento_ap,
                    //numero_documento_ap = pacientenoencontrado.numero_documento_ap,
                    //direccion_ap = pacientenoencontrado.direccion_ap,
                    //correo_electronico = pacientenoencontrado.correo_electronico,
                    //fecha_registro = DateTime.ParseExact(pacientenoencontrado.fecha_registro_string, "yyyy-MM-dd", CultureInfo.InvariantCulture),
                    //id_incapacidad = pacientenoencontrado.id_incapacidad,
                    //fecha_reporte = DateTime.ParseExact(pacientenoencontrado.fecha_reporte_string, "yyyy-MM-dd", CultureInfo.InvariantCulture),


                },
                commandType: CommandType.StoredProcedure);

                if (!string.IsNullOrWhiteSpace(result.ToList().FirstOrDefault().error))
                {
                    throw new Exception("Error en acceso a datos: " + result.ToList().FirstOrDefault().error);
                }

                return result.ToList().FirstOrDefault();

            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] { dataObject.ToString() });
            }
        }

        public RespuestBD InsertarAportante(Aportante aportante)
        {
            object dataObject = new { };
            try
            {
                using var connection = ConexionFactory.CrearConexion(EnumConexion.Write);
                var result = DapperWrapper.Query<RespuestBD>(connection, "dbo.Insertar_Aportante", dataObject = new
                {

                    tipo_documento = aportante.tipo_documento,
                    numero_documento = aportante.numero_documento,
                    razon_social = aportante.razon_social,
                    cod_depto = aportante.cod_depto,
                    cod_municipio = aportante.cod_municipio,
                    direccion = aportante.direccion,
                    correo_electronico = aportante.correo_electronico,
                },
                commandType: CommandType.StoredProcedure);
                return result.ToList().FirstOrDefault();

            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] { dataObject.ToString() });
            }

        }

        public int AnularIncapacidad(IncapacidadAnulada incapacidadanular)
        {
            object dataObject = new { };
            try
            {
                using (var connection = ConexionFactory.CrearConexion(EnumConexion.Write))
                {
                    var result = DapperWrapper.Execute(connection, "dbo.Insertar_Anulacion", dataObject = new
                    {

                        id_incapacidad = incapacidadanular.id_incapacidad,
                        causa_anulacion = incapacidadanular.causa_anulacion,
                        campos_anulacion = incapacidadanular.campos_causa,
                        observacion = incapacidadanular.observacion,
                        id_usuario_hercules = incapacidadanular.id_usuario_hercules,
                        retorno = 1
                    },
                    commandType: CommandType.StoredProcedure);
                    return result;
                }

            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] { dataObject.ToString() });
            }

        }


        public RespuestBD InsertarRelacionPacienteAfiliacionSalud(RelacionPacienteAfiliacionSalud relacionPacienteAfiliadoSalud)
        {
            object dataObject = new { };
            try
            {
                using (var connection = ConexionFactory.CrearConexion(EnumConexion.Write))
                {
                    var result = DapperWrapper.Query<RespuestBD>(connection, "dbo.Insertar_Paciente_AfiliacionS", dataObject = new
                    {
                        id_incapacidad = relacionPacienteAfiliadoSalud.id_incapacidad,
                        id_paciente = relacionPacienteAfiliadoSalud.id_paciente,
                        codigo_eps = relacionPacienteAfiliadoSalud.codigo_eps,
                        tipo_afiliado = relacionPacienteAfiliadoSalud.tipo_afiliado,
                        estado = relacionPacienteAfiliadoSalud.estado,
                        regimen = relacionPacienteAfiliadoSalud.regimen,
                        departamento_afil = relacionPacienteAfiliadoSalud.departamento_afil,
                        municipio_afil = relacionPacienteAfiliadoSalud.municipio_afil,

                        afiliado_PVS = relacionPacienteAfiliadoSalud.afiliado_PVS,
                        fecha_inicio_contrato = relacionPacienteAfiliadoSalud.fecha_inicio_contrato,

                        fecha_fin_contrato = relacionPacienteAfiliadoSalud.fecha_fin_contrato,
                        afiliado_INPEC = relacionPacienteAfiliadoSalud.afiliado_INPEC,
                        fecha_ingreso_inpec = relacionPacienteAfiliadoSalud.fecha_ingreso_inpec,
                        fecha_retiro_inpec = relacionPacienteAfiliadoSalud.fecha_retiro_inpec,
                        retorno = 0,
                    },
                    commandType: CommandType.StoredProcedure);
                    return result.ToList().FirstOrDefault();
                }

            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] { dataObject.ToString() });
            }
        }

        public RespuestBD regitrar_concepto_rehabilitacion(RegistroConceptoRehabilitacion conceptoRehabilitacion)
        {
            using var connection = ConexionFactory.CrearConexion(EnumConexion.Write);
            var result = DapperWrapper.Query<RespuestBD>(connection, "dbo.Insertar_Concepto_Rehabilitacion", new
            {
                id_incapacidad = conceptoRehabilitacion.id_incapacidad,
                id_documento_paciente = conceptoRehabilitacion.tipo_documento_pac,
                num_doc_paciente = conceptoRehabilitacion.numero_documento_pac,
                concepto_rehabilitacion = conceptoRehabilitacion.concepto_rehabilitacion.id_concepto_rehabilitacion,
                numero_concepto = conceptoRehabilitacion.numero_concepto,
                observaciones = conceptoRehabilitacion.observaciones,
                fecha_emision = conceptoRehabilitacion.fecha_emision,
                id_doc_medico_emite = conceptoRehabilitacion.id_doc_medico_emite,
                num_doc_medico_emite = conceptoRehabilitacion.numero_doc_medico_emite,
                id_entidad_registra = conceptoRehabilitacion.id_entidad_registra,
                num_doc_entidad_registra = conceptoRehabilitacion.numero_doc_entidad_registra,
                nombre_entidad_registra = conceptoRehabilitacion.nombre_entidad_registra,
                id_doc_medico_registra = conceptoRehabilitacion.id_doc_medico_registra,
                num_doc_medico_registra = conceptoRehabilitacion.numero_doc_medico_registra,
                nombres_medico_registra = conceptoRehabilitacion.nombres_medico_registra
            },
            commandType: CommandType.StoredProcedure);
            return result.ToList().FirstOrDefault();
        }

        public RespuestBD InsertarPerdidaCapacidadLaboral(PerdidaCapacidadLaboral pcl)
        {
            try
            {
                using var connection = ConexionFactory.CrearConexion(EnumConexion.Write);
                var result = DapperWrapper.Query<RespuestBD>(connection, "dbo.Insertar_Perdida_Capacidad_Laboral", new
                {
                    id_concepto_registro = pcl.id_concepto_registro,
                    numero_registro = pcl.numero_registro,
                    id_origen = pcl.id_origen,
                    porcentaje_perdida_capacidad_laboral = pcl.porcentaje_perdida_capacidad_laboral,
                    fecha_registro_calificacion = pcl.fecha_registro_calificacion,
                    fecha_calid_incapacidadificacion_PCL = pcl.fecha_calid_incapacidadificacion_PCL,
                    fecha_estructuracion = pcl.fecha_estructuracion,
                    nueva_calificacion = pcl.nueva_calificacion,
                    observaciones = pcl.observaciones,
                    tipo_profesional = pcl.tipo_profesional,
                    despacho_autoridad_judicial = pcl.despacho_autoridad_judicial,
                    nombres_apellidos_juez = pcl.nombres_apellidos_juez,
                    tipo_documento_entidad = pcl.tipo_documento_entidad,
                    numero_documento_entidad = pcl.numero_documento_entidad,
                    nombre_razon_social = pcl.nombre_razon_social,
                    tipo_documento_emite = pcl.tipo_documento_emite,
                    numero_documento_emite = pcl.numero_documento_emite,
                    nombre_profesional_emite = pcl.nombre_profesional_emite
                },
                commandType: CommandType.StoredProcedure);
                return result.ToList().FirstOrDefault();

            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] { });

            }

        }

        public void InsertarNotificacion(Notificacion notificacion)
        {
            object dataObject = new { };

            using (var connection = ConexionFactory.CrearConexion(EnumConexion.Write))
            {
                var result = DapperWrapper.Execute(connection, "dbo.Insertar_Notificacion", dataObject = new
                {

                    id_tipo_notificacion = notificacion.id_tipo_notificacion,
                    fecha_notificacion = notificacion.fecha_notificacion,
                    correo_destinatario = notificacion.correo_destinatario,
                    id_entidad_destino = notificacion.id_entidad_destino,
                    id_tipo_proceso = notificacion.id_tipo_proceso,
                    id_proceso = notificacion.id_proceso,
                    estado = notificacion.estado,
                },
                commandType: CommandType.StoredProcedure);
                
            }

        }

        public RespuestBD ObtenerSecuenciaPorCodigo(string codigo)
        {
            try
            {
                using var connection = ConexionFactory.CrearConexion(EnumConexion.Write);
                var result = DapperWrapper.Query<RespuestBD>(connection, "dbo.Obtener_Numero_Secuencia", new
                {
                    codigo
                },
                commandType: CommandType.StoredProcedure);
                return result.ToList().FirstOrDefault();

            }
            catch (Exception e)
            {
                throw new AppException(
                    e.Message, (e.InnerException != null ? e.InnerException.ToString() : ""), new string[] {  });
            }

        }

    }
}

