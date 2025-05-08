using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.DTO;
using Microsoft.Extensions.Configuration;
using NegocioIncapacidades;
using NegocioIncapacidades.Interfaces;
using ServiciosIncapacidades.Interfaces;
using ServiciosUtils;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiciosIncapacidades.Implementaciones
{
    public class RegistrarPagoServicio : IRegistrarPagoServicio
    {
        private readonly IRegistrarPagoNegocio registarPagoNegocio;
        private readonly IConfiguration configuration;
        private readonly IPagarIncapacidadProducerNegocio pagarIncapacidadProducerNegocio;
        private readonly IIncapacidadNegocio incapacidadNegocio;

        public RegistrarPagoServicio(IRegistrarPagoNegocio registarPagoNegocio, IConfiguration configuration, IPagarIncapacidadProducerNegocio pagarIncapacidadProducerNegocio, IIncapacidadNegocio incapacidadNegocio)
        {
            this.registarPagoNegocio = registarPagoNegocio;
            this.configuration = configuration;
            this.pagarIncapacidadProducerNegocio = pagarIncapacidadProducerNegocio;
            this.incapacidadNegocio = incapacidadNegocio;
        }

        public string AdicionarRegistrarPago(RegistrarPago registrarPago)
        {
            var registroPagoInsertado = registarPagoNegocio.NuevoRegistrarPago(registrarPago);

            if (registroPagoInsertado != null)
            {

                //Enviar notificación
                try
                {
                    if (configuration["Settings:ActiveNotifications"] == "true")
                    {
                        var incapacidad = incapacidadNegocio.ObtenerIncapacidad(registrarPago.id_incapacidad);

                        NotificarIncapacidadDTO notificacion = new NotificarIncapacidadDTO
                        {
                            id_incapacidad = registrarPago.id_incapacidad,
                            id_origen = incapacidad.id_origen,
                            paciente_encontrado = incapacidad.paciente_encontrado
                        };

                        pagarIncapacidadProducerNegocio.SendNotificationIncapacidadPagadaMessage(notificacion);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    var resultObjectLog = new { codigo = "501", mensaje = e.Message, detalle = e.InnerException != null ? e.InnerException.ToString().Replace("{", "(").Replace("}", ")") : string.Empty, data = "Error creando notificacion de registro de pago" };
                    LogFileService.Write(resultObjectLog.ToString());
                }
            }

            return registroPagoInsertado;
        }

        public IList<RegistrarPago> ConsultarRegistrosPago(RegistrarPago registrarPago)
        {
            return registarPagoNegocio.ConsultarRegistrosPago(registrarPago);
        }
    }
}

