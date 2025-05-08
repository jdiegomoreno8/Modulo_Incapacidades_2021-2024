using Common.ReadTemplateHelper;
using LibreriasIncapacidades.Modelos;
using LibreriasIncapacidades.Modelos.Constants;
using LibreriasIncapacidades.Modelos.DTO;
using NegocioIncapacidades.Interfaces;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Notificaciones.Consumer
{
    public class NotificacionExpedicionIncapacidadRehabilitacion : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IConfiguration _configuration;
        private readonly IReadTemplateHelper _readTemplateHelper;
        private readonly INotificacionIncapacidadNegocio _notificacionIncapacidad;
        private const string ExchangeNotificacionIncapacidadRehabilitacion = "ExchangeNotificacionIncapacidadRehabilitacion";

        public NotificacionExpedicionIncapacidadRehabilitacion(IConfiguration configuration, IReadTemplateHelper readTemplateHelper, INotificacionIncapacidadNegocio notificacionIncapacidad)
        {
            _configuration = configuration;
            _readTemplateHelper = readTemplateHelper;
            _notificacionIncapacidad = notificacionIncapacidad;
            var factory = new ConnectionFactory
            {
                HostName = _configuration["Rabbit:HostName"],
                UserName = _configuration["Rabbit:UserName"],
                Password = _configuration["Rabbit:Password"]
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(ExchangeNotificacionIncapacidadRehabilitacion, ExchangeType.Direct);
            _channel.QueueDeclare(BrokerConstant.ExchangeNotificacionIncapacidadRehabilitacionQueueName, false, false, false, null);
            _channel.QueueBind(BrokerConstant.ExchangeNotificacionIncapacidadRehabilitacionQueueName, ExchangeNotificacionIncapacidadRehabilitacion, BrokerConstant.ExchangeNotificacionIncapacidadRehabilitacionRouteKey);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                NotificarIncapacidadDTO notificacion = JsonConvert.DeserializeObject<NotificarIncapacidadDTO>(content);
                string template90 = _readTemplateHelper.ReadTemplate(_configuration["NotificacionExpedicionIncapacidadRehabilitacion90"]);
                string template120 = _readTemplateHelper.ReadTemplate(_configuration["NotificacionExpedicionIncapacidadRehabilitacionConcepto120"]);
                _notificacionIncapacidad.NotificacionRegistroConceptoRehabilitacionIncapacidad(notificacion, template90, template120);

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume(BrokerConstant.ExchangeNotificacionIncapacidadRehabilitacionQueueName, false, consumer);

            return Task.CompletedTask;
        }
    }
}
