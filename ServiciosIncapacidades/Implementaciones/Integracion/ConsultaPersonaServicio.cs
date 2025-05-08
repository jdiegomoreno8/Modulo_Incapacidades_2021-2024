using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.Integracion;
using Microsoft.Extensions.Configuration;
using NegocioIncapacidades;
using ServiciosIncapacidades.Interfaces;
using System.IO;

namespace ServiciosIncapacidades
{
    public class ConsultaPersonaServicio : IConsultaPersonaServicio
    {
        private readonly IPacienteMaestroPriorizadoNegocio pacienteMaestroPriorizadoNegocio;
        private readonly IConsultaSATServicio _consultaSATServicio;
        private readonly IPacienteServicio _pacienteServicio;
        private readonly IConsultaNacimientosDefuncionesServicio _consultaNacimientosDefuncionesServicio;
        private readonly IRelacionPacienteAfiliacionSaludServicio _relacionPacienteAfiliacionSaludServicio;
        private readonly IConfiguration _configuration;

        public ConsultaPersonaServicio(IPacienteMaestroPriorizadoNegocio pacienteMaestroPriorizadoNegocioIn, IConsultaSATServicio _consultaSATServicioIn,
                                        IPacienteServicio _pacienteServicioIn, IConsultaNacimientosDefuncionesServicio _consultaNacimientosDefuncionesServicioIn,
                                        IRelacionPacienteAfiliacionSaludServicio RelacionPacienteAfiliacionSaludServicioIn, IConfiguration _configurationIn)
        {
            pacienteMaestroPriorizadoNegocio = pacienteMaestroPriorizadoNegocioIn;
            _consultaSATServicio = _consultaSATServicioIn;
            _pacienteServicio = _pacienteServicioIn;
            _consultaNacimientosDefuncionesServicio = _consultaNacimientosDefuncionesServicioIn;
            _relacionPacienteAfiliacionSaludServicio = RelacionPacienteAfiliacionSaludServicioIn;
            _configuration = _configurationIn;
        }

        public Paciente Consultar(Paciente personaABuscar)
        {

            //string c = Directory.GetCurrentDirectory();
            //IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();

            string isServiceMaestroPriorizadoEnable = _configuration.GetSection("Settings:ServiceMaestroPriorizadoEnable").Value;
            string isServiceSATEnable = _configuration.GetSection("Settings:ServiceSATEnable").Value;
            string isServiceNDEnable = _configuration.GetSection("Settings:ServiceNDEnable").Value;

            MaestroPriorizado dataMaestroPriorizado = new MaestroPriorizado();
            Paciente pacienteSAT = new Paciente();
            Paciente paciente = null;

            if (isServiceMaestroPriorizadoEnable.Equals("true"))
            {
                dataMaestroPriorizado = pacienteMaestroPriorizadoNegocio.ConsultarPacienteMaestroPriorizado(personaABuscar);
            }

            if (isServiceSATEnable.Equals("true"))
            {
                pacienteSAT = _consultaSATServicio.ConsultarServicioSAT(personaABuscar);
                //pacienteSAT = _consultaSATServicio.ConsultarServicioSATMock(personaABuscar);
            }

            //Si encuentra paciente en Maestro Priorizado
            if (isServiceMaestroPriorizadoEnable.Equals("true") && !string.IsNullOrEmpty(dataMaestroPriorizado.primer_nombre))
            {
                paciente = ExtraerDatosMaestroPriorizado(dataMaestroPriorizado);

                //En MaestroPriorizado no hay aportantes, los trae de SAT
                paciente.aportantes = pacienteSAT.aportantes;
                paciente.relacionesPacienteAportante = pacienteSAT.relacionesPacienteAportante;

                paciente.info_consulta = "Paciente encontrado en Maestro Priorizado";

            }//busca en SAT
            else if (isServiceSATEnable.Equals("true") && !string.IsNullOrEmpty(pacienteSAT.primer_nombre))
            {
                paciente = pacienteSAT;

                paciente.info_consulta = "Paciente encontrado en SAT";
            }//busca en tabla de pacientes no encontrados
            else
            {


                var pacienteNoEncontrado = _pacienteServicio.ConsultarPacienteNoEncontrado(personaABuscar.tipo_documento, personaABuscar.numero_documento);

                if (pacienteNoEncontrado != null)
                {
                    paciente = pacienteNoEncontrado;
                    paciente.info_consulta = "Paciente encontrado en Tabla de Pacientes SIPE";

                    //var relacionPacienteAfiliacionConsultada = _relacionPacienteAfiliacionSaludServicio.ConsultarRelacionPacienteAfiliacionSalud(pacienteNoEncontrado.id_pacienteNoEncontrado);
                    //if (relacionPacienteAfiliacionConsultada != null)
                    //{
                    //    paciente.relacionPacienteAfiliacionSalud = relacionPacienteAfiliacionConsultada;
                    //}
                }
                else
                {
                    paciente = null;
                }

            }

            //Buscar en servicio Nacimientos y Defunciones
            if (isServiceNDEnable.Equals("true") && paciente != null)
            {
                personaABuscar.primer_nombre = paciente.primer_nombre;
                personaABuscar.primer_apellido = paciente.primer_apellido;
                Paciente pacienteNacimientosDefunciones = _consultaNacimientosDefuncionesServicio.ConsultarServicioNacimientosDefunciones(personaABuscar);
                if (!string.IsNullOrEmpty(pacienteNacimientosDefunciones.numeroCertificadoDefuncion))
                {
                    paciente.numeroCertificadoDefuncion = pacienteNacimientosDefunciones.numeroCertificadoDefuncion;
                }
            }


            //Paciente pacienteSAT = _consultaSATServicio.ConsultarServicioSAT(paciente);
            //paciente.aportantes = pacienteSAT.aportantes;
            //paciente.relacionesPacienteAportante = pacienteSAT.relacionesPacienteAportante;

            return paciente;
        }

        private Paciente ExtraerDatosMaestroPriorizado(MaestroPriorizado data)
        {
            Paciente paciente = new Paciente()
            {
                tipo_documento = data.tipo_identificacion,
                numero_documento = data.numero_identificacion,
                primer_nombre = data.primer_nombre,
                segundo_nombre = data.segundo_nombre,
                primer_apellido = data.primer_apellido,
                segundo_apellido = data.segundo_apellido,
                fecha_nacimiento = data.fecha_nacimiento,
                cod_depto_residencia = data.departamento_res,
                cod_mun_residencia = data.municipio_res,
                sexo = (data.sexo != null && data.sexo.Equals("F") ? "M" : data.sexo != null && data.sexo.Equals("M") ? "H" : "I")
            };

            RelacionPacienteAfiliacionSalud relacionPacienteAfiliacionSalud = new RelacionPacienteAfiliacionSalud()
            {
                id_incapacidad = "",
                id_paciente = 0,
                codigo_eps = data.Codigo_Entidad,
                tipo_afiliado = data.TipoAfiliado,
                estado = data.estado,
                regimen = data.Regimen,
                departamento_afil = data.departamento_afil,
                municipio_afil = data.municipio_afil,
                afiliado_PVS = data.MarcaPVS,
                fecha_inicio_contrato = data.FechaInicioContrato,
                fecha_fin_contrato = data.FechaFinalContrato,
                afiliado_INPEC = data.MarcaInpec,
                fecha_ingreso_inpec = data.FechaIngresoInpec,
                fecha_retiro_inpec = data.FechaRetiroInpec
            };

            //Aportante aportante1 = new Aportante()
            //{
            //    tipo_documento = "NIT",
            //    numero_documento = "820120120",
            //    razon_social = "Farmacia Centro",
            //    cod_depto = "",
            //    cod_municipio = "",
            //    correo_electronico = "",
            //    direccion = ""
            //};

            //Aportante aportante2 = new Aportante()
            //{
            //    tipo_documento = "NIT",
            //    numero_documento = "831121121",
            //    razon_social = "Farmacia Smart",
            //    cod_depto = "",
            //    cod_municipio = "",
            //    correo_electronico = "",
            //    direccion = ""
            //};

            //IList<Aportante> listaAportantes = new List<Aportante>
            //{
            //    aportante1,
            //    aportante2
            //};

            //RelacionPacienteAportante relacionPacienteAportante1 = new RelacionPacienteAportante()
            //{
            //    id_incapacidad = "",
            //    tipo_documento_pac = data.tipo_identificacion,
            //    numero_documento_pac = data.numero_identificacion,
            //    ultimo_periodo_salud = "2021",
            //    ultimo_periodo_afp_arl = "2021",
            //    cod_administradora_eps = "2021",
            //    cod_administradora_afp = "2021",
            //    cod_administradora_arl = "2021",
            //    IBC = 1,
            //    tipo_documento_ap = "NIT",
            //    numero_documento_ap = "820120120"
            //};

            //RelacionPacienteAportante relacionPacienteAportante2 = new RelacionPacienteAportante()
            //{
            //    id_incapacidad = "",
            //    tipo_documento_pac = data.tipo_identificacion,
            //    numero_documento_pac = data.numero_identificacion,
            //    ultimo_periodo_salud = "2022",
            //    ultimo_periodo_afp_arl = "2022",
            //    cod_administradora_eps = "2022",
            //    cod_administradora_afp = "2022",
            //    cod_administradora_arl = "2022",
            //    IBC = 1,
            //    tipo_documento_ap = "NIT",
            //    numero_documento_ap = "831121121"
            //};

            //IList<RelacionPacienteAportante> listaRelacionesPacienteAportante = new List<RelacionPacienteAportante>
            //{
            //    relacionPacienteAportante1,
            //    relacionPacienteAportante2
            //};

            //paciente.aportantes = listaAportantes;
            //paciente.relacionesPacienteAportante = listaRelacionesPacienteAportante;

            paciente.relacionPacienteAfiliacionSalud = relacionPacienteAfiliacionSalud;


            return paciente;
        }
    }
}
