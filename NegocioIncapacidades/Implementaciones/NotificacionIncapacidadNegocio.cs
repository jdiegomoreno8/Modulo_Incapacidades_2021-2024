using Common.EmailHelper;
using LibreriasIncapacidades.AccesoDatos;
using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.Constants;
using LibreriasIncapacidades.Modelos.DTO;
using NegocioIncapacidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.EmailHelper.EmailModel;

namespace NegocioIncapacidades.Implementaciones
{
    public class NotificacionIncapacidadNegocio : INotificacionIncapacidadNegocio
    {
        private readonly IEmailHelper _emailHelper;
        private readonly IAccesoDatosReadOnly incapacidadesRepositorioLectura;
        private readonly IAccesoDatosDataWrite incapacidadesRepositorioEscritura;

        public NotificacionIncapacidadNegocio(IEmailHelper emailHelper, IAccesoDatosReadOnly incapacidadesRepositorioLectura, IAccesoDatosDataWrite incapacidadesRepositorioEscritura)
        {
            this._emailHelper = emailHelper;
            this.incapacidadesRepositorioLectura = incapacidadesRepositorioLectura;
            this.incapacidadesRepositorioEscritura = incapacidadesRepositorioEscritura;
        }

        private async Task<bool> NotificarMailAdministradoraAsync(string tipoNotificacion, bool enviadoAdministradoraaAFPoColpensiones, NotificarIncapacidadDTO notificacionEncontrada, string template, string concepto = null)
        {
            //Administradoras (ARL o Eps segun origen)
            if (!enviadoAdministradoraaAFPoColpensiones)
            {
                if (!string.IsNullOrWhiteSpace(notificacionEncontrada.correo_administradora))
                {
                    int estadoEnvioMail;
                    if (tipoNotificacion == "expedicion")
                    {
                        Task<MailResponse> resultMailLaboral = NotificacionExpedicionAdministradora(notificacionEncontrada, template);
                        estadoEnvioMail = (await resultMailLaboral).Type == "Success" ? 1 : 0;
                    }
                    else if(tipoNotificacion == "anulacion")
                    {
                        Task<MailResponse> resultMailLaboral = NotificacionIncapacidadAnuladaEPSARL(notificacionEncontrada, template); //ARL
                        estadoEnvioMail = (await resultMailLaboral).Type == "Success" ? 1 : 0;
                    }
                    else if(tipoNotificacion == "prorrogaSinConcepto")
                    {
                        Task<MailResponse> resultMailNotificacion = NotificacionIncapacidadProrrogaSinConceptoRehabilitacionEPSARL(notificacionEncontrada, template);
                        estadoEnvioMail = (await resultMailNotificacion).Type == "Success" ? 1 : 0;
                    }
                    else if (tipoNotificacion == "prorroga120-150ConConcepto")
                    {
                        Task<MailResponse> resultMailNotificacion = NotificacionIncapacidadConProrroga120_150ConConceptoRehabilitacion(notificacionEncontrada, template, concepto);
                        estadoEnvioMail = (await resultMailNotificacion).Type == "Success" ? 1 : 0;
                    }
                    else
                    {
                        throw new Exception("No existe tipo de notificacicon");
                    }

                    enviadoAdministradoraaAFPoColpensiones = true;
                    InsertarNotificacion(new Notificacion { id_tipo_notificacion = 1, fecha_notificacion = DateTime.Now, id_entidad_destino = notificacionEncontrada.codigo_administradora, correo_destinatario = notificacionEncontrada.correo_administradora, id_tipo_proceso = 1, id_proceso = notificacionEncontrada.id_incapacidad, estado = estadoEnvioMail });
                }
                else
                {
                    InsertarNotificacion(new Notificacion { id_tipo_notificacion = 1, fecha_notificacion = DateTime.Now, id_entidad_destino = notificacionEncontrada.codigo_administradora, correo_destinatario = "No existe", id_tipo_proceso = 1, id_proceso = notificacionEncontrada.id_incapacidad, estado = 0 });
                }
            }
            return enviadoAdministradoraaAFPoColpensiones;
        }

        private async Task NotificarMailAportanteAsync(string tipoNotificacion, NotificarIncapacidadDTO notificacionEncontrada, string template)
        {
            if (!string.IsNullOrWhiteSpace(notificacionEncontrada.correo_aportante))
            {
                int estadoEnvioMail;
                if (tipoNotificacion == "expedicion")
                {
                    Task<MailResponse> resultMailAportante = NotificacionExpedicionEmpleador(notificacionEncontrada, template); //Aportante(s)
                    estadoEnvioMail = (await resultMailAportante).Type == "Success" ? 1 : 0;
                }
                else
                {
                    Task<MailResponse> resultMailAportante = NotificacionIncapacidadAnuladaEmpleador(notificacionEncontrada, template); //ARL
                    estadoEnvioMail = (await resultMailAportante).Type == "Success" ? 1 : 0;
                }

                InsertarNotificacion(new Notificacion { id_tipo_notificacion = 1, fecha_notificacion = DateTime.Now, id_entidad_destino = notificacionEncontrada.codigo_aportante, correo_destinatario = notificacionEncontrada.correo_aportante, id_tipo_proceso = 1, id_proceso = notificacionEncontrada.id_incapacidad, estado = estadoEnvioMail });
            }
            else
            {
                InsertarNotificacion(new Notificacion { id_tipo_notificacion = 1, fecha_notificacion = DateTime.Now, id_entidad_destino = notificacionEncontrada.codigo_aportante, correo_destinatario = "No existe", id_tipo_proceso = 1, id_proceso = notificacionEncontrada.id_incapacidad, estado = 0 });
            }
        }
        
        
        #region NotificacionExpedicionIncapacidad
        public async Task NotificacionExpedicionIncapacidad(NotificarIncapacidadDTO notifacion, string templateAdministradora, string templateEmpleador, string templateAFP)
        {
            //Notificar Administradora
            var resultNotificar = incapacidadesRepositorioLectura.Consultar_Notificar_Incapacidad(notifacion);

            bool enviadoAdministradoraaAFPoColpensiones = false;

            foreach (var notificacionEncontrada in resultNotificar)
            {
                if (notificacionEncontrada.origen == "Laboral")
                {
                    //Administradoras (ARL o Eps segun origen)
                    enviadoAdministradoraaAFPoColpensiones = await NotificarMailAdministradoraAsync("expedicion", enviadoAdministradoraaAFPoColpensiones, notificacionEncontrada, templateAdministradora);

                    await NotificarMailAportanteAsync("expedicion", notificacionEncontrada, templateEmpleador);
                }
                else //origen Común
                {
                    //regimen contributivo
                    if (notificacionEncontrada.codigo_regimen == "C")
                    {
                        if (notificacionEncontrada.dias_acumulados_prorroga < 180 || notificacionEncontrada.dias_acumulados_prorroga >= 180)
                        {
                            //Administradoras (ARL o Eps segun origen)
                            enviadoAdministradoraaAFPoColpensiones = await NotificarMailAdministradoraAsync("expedicion", enviadoAdministradoraaAFPoColpensiones, notificacionEncontrada, templateAdministradora);
                        }
                        else
                        {
                            //Administradoras (AFP o Colpensiones)
                            enviadoAdministradoraaAFPoColpensiones = await NotificarMailAdministradoraAsync("expedicion", enviadoAdministradoraaAFPoColpensiones, notificacionEncontrada, templateAFP);
                        }

                        await NotificarMailAportanteAsync("expedicion", notificacionEncontrada, templateEmpleador);

                    }
                    else if (notificacionEncontrada.codigo_regimen == "E" || notificacionEncontrada.codigo_regimen == "ES" || notificacionEncontrada.codigo_regimen == "EX" || notificacionEncontrada.codigo_regimen == "P")
                    //regimen especial y excepcion?
                    {
                        //ADRES
                        //to do
                        enviadoAdministradoraaAFPoColpensiones = await NotificarMailAdministradoraAsync("expedicion", enviadoAdministradoraaAFPoColpensiones, notificacionEncontrada, templateAdministradora);

                        await NotificarMailAportanteAsync("expedicion", notificacionEncontrada, templateEmpleador);

                    }
                }
            }
        }

        

        public void InsertarNotificacion(Notificacion notificacion)
        {
            incapacidadesRepositorioEscritura.InsertarNotificacion(notificacion);
        }

        private Task<MailResponse> NotificacionExpedicionAdministradora(NotificarIncapacidadDTO notificacion, string template)
        {
            //Reemplazar datos del cuerpo
            template = template.Replace("(nombre ARL, EPS, ADRES)", notificacion.administradora);
            template = template.Replace("(número incapacidad)", notificacion.id_incapacidad);
            template = template.Replace("(laboral o común)", notificacion.origen);
            template = template.Replace("(nombres y apellidos del paciente)", $"{notificacion.primer_nom_pac} {notificacion.segundo_nom_pac} {notificacion.primer_ap_pac} {notificacion.segundo_ap_pac}");
            template = template.Replace("(tipo documento)", notificacion.tipo_doc_paciente);
            template = template.Replace("(número de documento)", notificacion.num_doc_paciente);
            template = template.Replace("(fecha expedición de la incapacidad)", notificacion.fecha_expedicion.ToShortDateString());
            template = template.Replace("(días Incapacidad)", notificacion.dias_incapacidad.ToString());

            var email = new EmailModel()
            {
                Subject = NotificacionConstant.NotificacionExpedicionIncapacidad,
                FromDisplayName = NotificacionConstant.EmailExpedicionIncapacidad,
                Body = new BodyMail()
                {
                    Title = string.Empty,
                    HtmlContent = template
                },
                Type = MailType.Email,
                Addressee = new DestinationMail()
                {
                    To = new List<string>() { notificacion.correo_administradora }
                }
            };
            return _emailHelper.SendEmail(email);
        }

        private Task<MailResponse> NotificacionExpedicionEmpleador(NotificarIncapacidadDTO notificacion, string template)
        {
            //Reemplazar datos del cuerpo
            template = template.Replace("(NIT y Razón Social)", notificacion.Aportante);
            template = template.Replace("(número incapacidad)", notificacion.id_incapacidad);
            template = template.Replace("(laboral o común)", notificacion.origen);
            template = template.Replace("(nombres y apellidos del paciente)", $"{notificacion.primer_nom_pac} {notificacion.segundo_nom_pac} {notificacion.primer_ap_pac} {notificacion.segundo_ap_pac}");
            template = template.Replace("(tipo documento)", notificacion.tipo_doc_paciente);
            template = template.Replace("(número de documento)", notificacion.num_doc_paciente);
            template = template.Replace("(fecha expedición de la incapacidad)", notificacion.fecha_expedicion.ToShortDateString());
            template = template.Replace("(días Incapacidad)", notificacion.dias_incapacidad.ToString());

            var email = new EmailModel()
            {
                Subject = NotificacionConstant.NotificacionExpedicionIncapacidad,
                FromDisplayName = NotificacionConstant.EmailExpedicionIncapacidad,
                Body = new BodyMail()
                {
                    Title = string.Empty,
                    HtmlContent = template
                },
                Type = MailType.Email,
                Addressee = new DestinationMail()
                {
                    To = new List<string>() { notificacion.correo_aportante }
                }
            };
            return _emailHelper.SendEmail(email);
        }

        //private Task<MailResponse> NotificacionExpedicionAFP(NotificarIncapacidadDTO notificacion, string template)
        //{
        //    //Reemplazar datos del cuerpo
        //    template = template.Replace("(nombre AFP o Colpensiones)", notificacion.administradora);
        //    template = template.Replace("(número incapacidad)", notificacion.id_incapacidad);
        //    template = template.Replace("(laboral o común)", notificacion.origen);
        //    template = template.Replace("(nombres y apellidos del paciente)", $"{notificacion.primer_nom_pac} {notificacion.segundo_nom_pac} {notificacion.primer_ap_pac} {notificacion.segundo_ap_pac}");
        //    template = template.Replace("(tipo y numero de documento)", $"{notificacion.tipo_doc_paciente} {notificacion.num_doc_paciente}");
        //    template = template.Replace("(fecha expedición de la incapacidad)", notificacion.fecha_expedicion.ToShortDateString());
        //    template = template.Replace("(fecha inicio incapacidad)", notificacion.fecha_inicio.ToShortDateString());
        //    template = template.Replace("(Numero días Incapacidad)", notificacion.dias_incapacidad.ToString());
        //    template = template.Replace("(fecha fin incapacidad)", notificacion.fecha_fin.ToShortDateString().ToString());

        //    var email = new EmailModel()
        //    {
        //        Subject = NotificacionConstant.NotificacionExpedicionIncapacidad,
        //        FromDisplayName = NotificacionConstant.EmailExpedicionIncapacidad,
        //        Body = new BodyMail()
        //        {
        //            Title = string.Empty,
        //            HtmlContent = template
        //        },
        //        Type = MailType.Email,
        //        Addressee = new DestinationMail()
        //        {
        //            To = new List<string>() { notificacion.correo_administradora}
        //        }
        //    };
        //    return _emailHelper.SendEmail(email);
        //}
        #endregion


        #region NotificacionIncapacidadAnulada
        public async Task NotificacionIncapacidadAnulada(NotificarIncapacidadDTO notificacion, string templateAdministradora, string templateEmpleador, string templateAFP)
        {
            //Notificar Administradora
            var resultNotificar = incapacidadesRepositorioLectura.Consultar_Notificar_Incapacidad(notificacion);

            bool enviadoAdministradora = false;
            foreach (var notificacionEncontrada in resultNotificar)
            {
                if (notificacionEncontrada.origen == "Laboral")
                {
                    enviadoAdministradora = await NotificarMailAdministradoraAsync("anulacion", enviadoAdministradora, notificacionEncontrada, templateAdministradora);

                    await NotificarMailAportanteAsync("anulacion", notificacionEncontrada, templateEmpleador);
                }
                else //origen Común
                {
                    //regimen contributivo
                    if (notificacionEncontrada.codigo_regimen == "C")
                    {

                        if (notificacionEncontrada.dias_acumulados_prorroga < 180 || notificacionEncontrada.dias_acumulados_prorroga >= 180)
                        {
                            //Administradoras (ARL o Eps segun origen)
                            enviadoAdministradora = await NotificarMailAdministradoraAsync("anulacion", enviadoAdministradora, notificacionEncontrada, templateAdministradora);
                        }
                        else
                        {
                            //Administradoras (AFP o Colpensiones)
                            enviadoAdministradora = await NotificarMailAdministradoraAsync("anulacion", enviadoAdministradora, notificacionEncontrada, templateAFP);
                        }
                        await NotificarMailAportanteAsync("anulacion", notificacionEncontrada, templateEmpleador);

                    }
                    else if (notificacionEncontrada.codigo_regimen == "E" || notificacionEncontrada.codigo_regimen == "ES" || notificacionEncontrada.codigo_regimen == "EX" || notificacionEncontrada.codigo_regimen == "P")
                    //regimen especial y excepcion?
                    {
                        //ADRES
                        //to do y a´portante?
                        enviadoAdministradora = await NotificarMailAdministradoraAsync("anulacion", enviadoAdministradora, notificacionEncontrada, templateAFP);

                        await NotificarMailAportanteAsync("anulacion", notificacionEncontrada, templateEmpleador);

                    }
                }
            }

        }

        private async Task<MailResponse> NotificacionIncapacidadAnuladaEPSARL(NotificarIncapacidadDTO notificacion, string template)
        {
            //Reemplazar datos del cuerpo
            template = template.Replace("(Razón Social y NIT)", notificacion.administradora);
            template = template.Replace("(Número Incapacidad)", notificacion.id_incapacidad);
            template = template.Replace("(nombres y apellidos del paciente)", $"{notificacion.primer_nom_pac} {notificacion.segundo_nom_pac} {notificacion.primer_ap_pac} {notificacion.segundo_ap_pac}");
            template = template.Replace("(tipo y numero de documento)", notificacion.tipo_doc_paciente + " " + notificacion.num_doc_paciente);
            template = template.Replace("(fecha de la anulación)", notificacion.fecha_anulacion.ToShortDateString());//todo

            var email = new EmailModel()
            {
                Subject = NotificacionConstant.NotificacionIncapacidadAnulada,
                FromDisplayName = NotificacionConstant.NotificacionIncapacidadAnulada,
                Body = new BodyMail()
                {
                    Title = string.Empty,
                    HtmlContent = template
                },
                Type = MailType.Email,
                Addressee = new DestinationMail()
                {
                    To = new List<string>() { notificacion.correo_administradora}
                }
            };
            return await _emailHelper.SendEmail(email);
        }

        private async Task<MailResponse> NotificacionIncapacidadAnuladaEmpleador(NotificarIncapacidadDTO notificacion, string template)
        {
            //Reemplazar datos del cuerpo
            template = template.Replace("(nombre ARL, EPS, ADRES)", notificacion.administradora);
            template = template.Replace("(Número Incapacidad)", notificacion.id_incapacidad);
            template = template.Replace("(nombres y apellidos del paciente)", $"{notificacion.primer_nom_pac} {notificacion.segundo_nom_pac} {notificacion.primer_ap_pac} {notificacion.segundo_ap_pac}");
            template = template.Replace("(tipo y numero de documento)", notificacion.tipo_doc_paciente + " " + notificacion.num_doc_paciente);
            template = template.Replace("(fecha de la anulación)", notificacion.fecha_anulacion.ToShortDateString());//todo

            var email = new EmailModel()
            {
                Subject = NotificacionConstant.NotificacionIncapacidadAnulada,
                FromDisplayName = NotificacionConstant.NotificacionIncapacidadAnulada,
                Body = new BodyMail()
                {
                    Title = string.Empty,
                    HtmlContent = template
                },
                Type = MailType.Email,
                Addressee = new DestinationMail()
                {
                    To = new List<string>() { notificacion.correo_administradora }
                }
            };
            return await _emailHelper.SendEmail(email);
        }
        #endregion


        #region Notificacion Incapacidad Rehabilitacion
        public async Task NotificacionRegistroConceptoRehabilitacionIncapacidad(NotificarIncapacidadDTO notificacion, string template90, string template120)
        {
            bool enviadoAdministradora = false;
            //Notificar Administradora
            var resultNotificar = incapacidadesRepositorioLectura.GetNotificar_IncapacidadARehabilitacion(notificacion);

            foreach (var notificar in resultNotificar)
            {
                var rehabilitacion = incapacidadesRepositorioLectura.GetIncapacidadARehabilitacion(new Incapacidad { id_incapacidad = notificacion.id_incapacidad});

                enviadoAdministradora = await NotificarMailAdministradoraAsync("prorrogaSinConcepto", enviadoAdministradora, notificar, template90);

                if (rehabilitacion.Count > 0 && notificacion.dias_incapacidad >= 120)
                {
                    enviadoAdministradora = await NotificarMailAdministradoraAsync("prorroga120-150ConConcepto", enviadoAdministradora, notificar, template120, rehabilitacion.FirstOrDefault().concepto_rehabilitacion.descripcion);
                }
            }
        }

        private async Task<MailResponse> NotificacionIncapacidadProrrogaSinConceptoRehabilitacionEPSARL(NotificarIncapacidadDTO notificacion, string template)
        {
            //Reemplazar datos del cuerpo
            template = template.Replace("(nombre ARL, EPS, ADRES)", notificacion.administradora);
            template = template.Replace("(Número Incapacidad)", notificacion.id_incapacidad);
            template = template.Replace("(laboral o común)", notificacion.origen);
            template = template.Replace("(nombres y apellidos del paciente)", $"{notificacion.primer_nom_pac} {notificacion.segundo_nom_pac} {notificacion.primer_ap_pac} {notificacion.segundo_ap_pac}");
            template = template.Replace("(número de documento)", notificacion.num_doc_paciente);

            var email = new EmailModel()
            {
                Subject = NotificacionConstant.NotificacionIncapacidadRehabilitacion90,
                FromDisplayName = NotificacionConstant.NotificacionIncapacidadRehabilitacion90,
                Body = new BodyMail()
                {
                    Title = string.Empty,
                    HtmlContent = template
                },
                Type = MailType.Email,
                Addressee = new DestinationMail()
                {
                    To = new List<string>() { notificacion.correo_administradora}
                }
            };
            return await _emailHelper.SendEmail(email);
        }

        private async Task<MailResponse> NotificacionIncapacidadConProrroga120_150ConConceptoRehabilitacion(NotificarIncapacidadDTO notificacion, string template, string concepto)
        {
            //Reemplazar datos del cuerpo
            template = template.Replace("(nombre AFP)", notificacion.administradora);
            template = template.Replace("(nombres y apellidos del paciente)", $"{notificacion.primer_nom_pac} {notificacion.segundo_nom_pac} {notificacion.primer_ap_pac} {notificacion.segundo_ap_pac}");
            template = template.Replace("(tipo y numero de documento)", notificacion.tipo_doc_paciente + " " + notificacion.num_doc_paciente);
            template = template.Replace("(Concepto Rehabilitación)", concepto);

            var email = new EmailModel()
            {
                Subject = NotificacionConstant.NotificacionIncapacidadRehabilitacion120,
                FromDisplayName = NotificacionConstant.NotificacionIncapacidadRehabilitacion120,
                Body = new BodyMail()
                {
                    Title = string.Empty,
                    HtmlContent = template
                },
                Type = MailType.Email,
                Addressee = new DestinationMail()
                {
                    To = new List<string>() { notificacion.correo_administradora }
                }
            };
            return await _emailHelper.SendEmail(email);
        }
        #endregion

        #region Notificacion Incapacidad Pagada
        public async Task NotificacionIncapacidadPagada(NotificarIncapacidadPagadaDTO incapacidad, string template)
        {
            //Notificar Empleador
            var resultNotificar = incapacidadesRepositorioLectura.Consultar_Notificar_Incapacidad_Pagada(incapacidad);

            foreach (var notificar in resultNotificar)
            {
                Task<MailResponse> resultMail = NotificacionIncapacidadPagadaEmpleador(notificar, template);
                InsertarNotificacion(new Notificacion { id_tipo_notificacion = 2, fecha_notificacion = DateTime.Now, id_entidad_destino = notificar.codigo_aportante, correo_destinatario = notificar.correo_aportante, id_tipo_proceso = 1, id_proceso = notificar.id_incapacidad, estado = ((await resultMail).Type == "Success" ? 1 : 0) });
            }
        }

        private Task<MailResponse> NotificacionIncapacidadPagadaEmpleador(NotificarIncapacidadPagadaDTO notificacion, string template)
        {
            //Reemplazar datos del cuerpo
            template = template.Replace("(Razón Social y NIT)", notificacion.Aportante);
            template = template.Replace("(número incapacidad)", notificacion.id_incapacidad);
            template = template.Replace("(laboral o común)", notificacion.origen);
            template = template.Replace("(nombres y apellidos del paciente)", $"{notificacion.primer_nom_pac} {notificacion.segundo_nom_pac} {notificacion.primer_ap_pac} {notificacion.segundo_ap_pac}");
            template = template.Replace("(tipo documento)", notificacion.tipo_doc_paciente);
            template = template.Replace("(número de documento)", notificacion.num_doc_paciente);
            template = template.Replace("(fecha de pago Incapacidad)", notificacion.fecha_pago.ToShortTimeString());
            template = template.Replace("(valor pagado incapacidad)", notificacion.valor_pagado.ToString());

            var email = new EmailModel()
            {
                Subject = NotificacionConstant.NotificacionIncapacidadPagada,
                FromDisplayName = NotificacionConstant.NotificacionIncapacidadPagada,
                Body = new BodyMail()
                {
                    Title = string.Empty,
                    HtmlContent = template
                },
                Type = MailType.Email,
                Addressee = new DestinationMail()
                {
                    To = new List<string>() { notificacion.correo_aportante }
                }
            };
            return _emailHelper.SendEmail(email);
        }

        #endregion
    }
}