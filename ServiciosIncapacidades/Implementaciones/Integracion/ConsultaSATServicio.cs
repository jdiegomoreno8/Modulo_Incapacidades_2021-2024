using LibreriasIncapacidades.Modelos;
using Microsoft.Extensions.Configuration;
using NegocioIncapacidades;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace ServiciosIncapacidades
{
    public class ConsultaSATServicio : IConsultaSATServicio
    {

        private static HttpClientHelper<PersonaSAT> Client { get; set; }

        public ConsultaSATServicio(IPacienteMaestroPriorizadoNegocio pacienteMaestroPriorizadoNegocioIn)
        {
            string c = Directory.GetCurrentDirectory();
            IConfiguration _configuration = new ConfigurationBuilder().SetBasePath(c).AddJsonFile("appsettings.json").Build();

            Client = new HttpClientHelper<PersonaSAT>(_configuration.GetConnectionString("SATService"));
        }

        public Paciente ConsultarServicioSAT(Paciente pacienteABuscar)
        {
            string stringData = JsonConvert.SerializeObject(new { TipoDocumento = pacienteABuscar.tipo_documento, NumeroDocumento = pacienteABuscar.numero_documento });
            PersonaSAT personaSAT = //new PersonaSAT("test");
                                    Client.PostRequest("/ConsultarAfiliacionesPaciente", stringData).Result;

            Paciente paciente = new Paciente();

            if (!string.IsNullOrEmpty(personaSAT.primerNombre))
            {
                paciente.tipo_documento = personaSAT.tipoDocumento;
                paciente.numero_documento = personaSAT.numeroDocumento;
                paciente.primer_nombre = personaSAT.primerNombre;
                paciente.segundo_nombre = personaSAT.segundoNombre;
                paciente.primer_apellido = personaSAT.primerApellido;
                paciente.segundo_apellido = personaSAT.segundoApellido;
                paciente.sexo = personaSAT.sexo;

                //paciente.e =personaSAT.EstadoDocumentoAfiliado ;
                //paciente. =personaSAT.CodigoEPS               ;
                //paciente. =personaSAT.EstadoAfiliacionEPS     ;
                //paciente. =personaSAT.TipoAfiliado            ;
                //paciente. =personaSAT.Regimen                 ;
                //paciente. =personaSAT.CodigoAFP               ;
                //paciente. =personaSAT.EstadoAfilliacionAFP    ;
                //paciente. =personaSAT.CodigoARL               ;
                //paciente. =personaSAT.EstadoAfilliacionARL    ;
                //paciente. =personaSAT.RazonSocialAportante    ;
                //paciente. =personaSAT.TipoDocumentoAportante  ;
                //paciente. =personaSAT.DocumentoAportante      ;
                //paciente. =personaSAT.EmailAportante          ;
                //Estado = personaSAT.EmailAportante;


                RelacionPacienteAfiliacionSalud relacionPacienteAfiliacionSalud = new RelacionPacienteAfiliacionSalud()
                {
                    id_incapacidad = "",
                    id_paciente = 0,
                    codigo_eps = personaSAT.codigoEPS,
                    tipo_afiliado = personaSAT.tipoAfiliado,
                    estado = personaSAT.estadoAfiliacionEPS,
                    regimen = personaSAT.regimen,
                    //departamento_afil = data.departamento_afil,
                    //municipio_afil = data.municipio_afil,
                    //afiliado_PVS = data.MarcaPVS,
                    //fecha_inicio_contrato = data.FechaInicioContrato,
                    //fecha_fin_contrato = data.FechaFinalContrato,
                    //afiliado_INPEC = data.MarcaInpec,
                    //fecha_ingreso_inpec = data.FechaIngresoInpec,
                    //fecha_retiro_inpec = data.FechaRetiroInpec
                };

                IList<Aportante> listaAportantes = new List<Aportante>();
                foreach (var afiliacionSAT in personaSAT.afiliacionesARL)
                {
                    Aportante aportanteConsulta = new Aportante()
                    {
                        tipo_documento = afiliacionSAT.tipoDocumentoAportante,
                        numero_documento = afiliacionSAT.documentoAportante.ToString(),
                        razon_social = afiliacionSAT.razonSocialAportante,
                        cod_depto = "",
                        cod_municipio = "",
                        correo_electronico = afiliacionSAT.emailAportante,
                        direccion = ""
                    };
                    listaAportantes.Add(aportanteConsulta);
                }

                IList<RelacionPacienteAportante> listaRelacionesPacienteAportante = new List<RelacionPacienteAportante>();
                foreach (var afiliacionSAT in personaSAT.afiliacionesARL)
                {
                    RelacionPacienteAportante relacionPacienteAportante1 = new RelacionPacienteAportante()
                    {
                        id_incapacidad = "",
                        tipo_documento_pac = pacienteABuscar.tipo_documento,
                        numero_documento_pac = pacienteABuscar.numero_documento,
                        ultimo_periodo_salud = "",
                        ultimo_periodo_afp_arl = "",
                        cod_administradora_eps = personaSAT.codigoEPS,
                        cod_administradora_afp = personaSAT.codigoAFP,
                        cod_administradora_arl = afiliacionSAT.codigoARL,
                        IBC = 1,
                        tipo_documento_ap = afiliacionSAT.tipoDocumentoAportante,
                        numero_documento_ap = afiliacionSAT.documentoAportante.ToString()
                    };
                    listaRelacionesPacienteAportante.Add(relacionPacienteAportante1);
                }

                paciente.relacionPacienteAfiliacionSalud = relacionPacienteAfiliacionSalud;
                paciente.aportantes = listaAportantes;
                paciente.relacionesPacienteAportante = listaRelacionesPacienteAportante;

            }
            return paciente;

        }

        public Paciente ConsultarServicioSATMock(Paciente pacienteABuscar)
        {
            string stringData = JsonConvert.SerializeObject(new { TipoDocumento = pacienteABuscar.tipo_documento, NumeroDocumento = pacienteABuscar.numero_documento });
            PersonaSAT personaSAT = //new PersonaSAT("test");
                                    Client.PostRequest("/ConsultarAfiliacionesPaciente", stringData).Result;

            Paciente paciente = new Paciente();

            if (!string.IsNullOrEmpty(personaSAT.primerNombre))
            {
                paciente.tipo_documento = personaSAT.tipoDocumento;
                paciente.numero_documento = personaSAT.numeroDocumento;
                paciente.primer_nombre = personaSAT.primerNombre;
                paciente.segundo_nombre = personaSAT.segundoNombre;
                paciente.primer_apellido = personaSAT.primerApellido;
                paciente.segundo_apellido = personaSAT.segundoApellido;
                paciente.sexo = personaSAT.sexo;

                //paciente.e =personaSAT.EstadoDocumentoAfiliado ;
                //paciente. =personaSAT.CodigoEPS               ;
                //paciente. =personaSAT.EstadoAfiliacionEPS     ;
                //paciente. =personaSAT.TipoAfiliado            ;
                //paciente. =personaSAT.Regimen                 ;
                //paciente. =personaSAT.CodigoAFP               ;
                //paciente. =personaSAT.EstadoAfilliacionAFP    ;
                //paciente. =personaSAT.CodigoARL               ;
                //paciente. =personaSAT.EstadoAfilliacionARL    ;
                //paciente. =personaSAT.RazonSocialAportante    ;
                //paciente. =personaSAT.TipoDocumentoAportante  ;
                //paciente. =personaSAT.DocumentoAportante      ;
                //paciente. =personaSAT.EmailAportante          ;
                //Estado = personaSAT.EmailAportante;


                RelacionPacienteAfiliacionSalud relacionPacienteAfiliacionSalud = new RelacionPacienteAfiliacionSalud()
                {
                    id_incapacidad = "",
                    id_paciente = 0,
                    codigo_eps = personaSAT.codigoEPS,
                    tipo_afiliado = personaSAT.tipoAfiliado,
                    estado = personaSAT.estadoAfiliacionEPS,
                    regimen = personaSAT.regimen,
                    //departamento_afil = data.departamento_afil,
                    //municipio_afil = data.municipio_afil,
                    //afiliado_PVS = data.MarcaPVS,
                    //fecha_inicio_contrato = data.FechaInicioContrato,
                    //fecha_fin_contrato = data.FechaFinalContrato,
                    //afiliado_INPEC = data.MarcaInpec,
                    //fecha_ingreso_inpec = data.FechaIngresoInpec,
                    //fecha_retiro_inpec = data.FechaRetiroInpec
                };

                IList<Aportante> listaAportantes = new List<Aportante>();
                foreach (var afiliacionSAT in personaSAT.afiliacionesARL)
                {
                    Aportante aportanteConsulta = new Aportante()
                    {
                        tipo_documento = afiliacionSAT.tipoDocumentoAportante,
                        numero_documento = afiliacionSAT.documentoAportante.ToString(),
                        razon_social = afiliacionSAT.razonSocialAportante,
                        cod_depto = "",
                        cod_municipio = "",
                        correo_electronico = afiliacionSAT.emailAportante,
                        direccion = ""
                    };
                    listaAportantes.Add(aportanteConsulta);
                }

                IList<RelacionPacienteAportante> listaRelacionesPacienteAportante = new List<RelacionPacienteAportante>();
                foreach (var afiliacionSAT in personaSAT.afiliacionesARL)
                {
                    RelacionPacienteAportante relacionPacienteAportante1 = new RelacionPacienteAportante()
                    {
                        id_incapacidad = "",
                        tipo_documento_pac = pacienteABuscar.tipo_documento,
                        numero_documento_pac = pacienteABuscar.numero_documento,
                        ultimo_periodo_salud = "",
                        ultimo_periodo_afp_arl = "",
                        cod_administradora_eps = personaSAT.codigoEPS,
                        cod_administradora_afp = personaSAT.codigoAFP,
                        cod_administradora_arl = afiliacionSAT.codigoARL,
                        IBC = 1,
                        tipo_documento_ap = afiliacionSAT.tipoDocumentoAportante,
                        numero_documento_ap = afiliacionSAT.documentoAportante.ToString()
                    };
                    listaRelacionesPacienteAportante.Add(relacionPacienteAportante1);
                }

                paciente.relacionPacienteAfiliacionSalud = relacionPacienteAfiliacionSalud;
                paciente.aportantes = listaAportantes;
                paciente.relacionesPacienteAportante = listaRelacionesPacienteAportante;

            }
            return paciente;

        }
    }
}
