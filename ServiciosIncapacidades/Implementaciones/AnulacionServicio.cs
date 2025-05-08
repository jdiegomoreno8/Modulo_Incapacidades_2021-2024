using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.DTO;
using Microsoft.Extensions.Configuration;
using Negocio;
using NegocioIncapacidades;
using ServiciosUtils;
using System;

namespace ServiciosIncapacidades
{
    public class AnulacionServicio : IAnulacionServicio
    {
        private readonly IAnulacionNegocio anulacionNegocio;
        private readonly IConfiguration configuration;
        private readonly IAnularIncapacidadProducerNegocio anularIncapacidadProducerNegocio;
        private readonly IIncapacidadNegocio incapacidadNegocio;

        public AnulacionServicio(IAnulacionNegocio AnulacionNegocio, IConfiguration configuration, 
            IAnularIncapacidadProducerNegocio anularIncapacidadProducerNegocio, IIncapacidadNegocio incapacidadNegocio)
        {
            this.anulacionNegocio = AnulacionNegocio;
            this.configuration = configuration;
            this.anularIncapacidadProducerNegocio = anularIncapacidadProducerNegocio;
            this.incapacidadNegocio = incapacidadNegocio;
        }

        public int AnularIncapacidad(IncapacidadAnulada incapacidadAnulada)
        {
            int anulada = anulacionNegocio.AnularIncapacidad(incapacidadAnulada);

            if (anulada > 0)
            {
                //Enviar notificación
                try
                {
                    if (configuration["Settings:ActiveNotifications"] == "true")
                    {
                        var incapacidad = incapacidadNegocio.ObtenerIncapacidad(incapacidadAnulada.id_incapacidad);

                        NotificarIncapacidadDTO notificacion = new NotificarIncapacidadDTO
                        {
                            id_incapacidad = incapacidadAnulada.id_incapacidad,
                            id_origen = incapacidad.id_origen,
                            paciente_encontrado = incapacidad.paciente_encontrado,
                            fecha_anulacion = incapacidad.fecha_anulacion
                        };

                        anularIncapacidadProducerNegocio.SendNotificationAnularIncapacidadMessage(notificacion);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    var resultObjectLog = new { codigo = "501", mensaje = e.Message, detalle = e.InnerException != null ? e.InnerException.ToString().Replace("{", "(").Replace("}", ")") : string.Empty, data = "Error creando notificacion de anulación" };
                    LogFileService.Write(resultObjectLog.ToString());
                }
            }

            return anulada;
        }
    }
}
