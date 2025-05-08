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
    public class NotificacionExpedicionIncapacidadPagada : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IConfiguration _configuration;
        private readonly IReadTemplateHelper _readTemplateHelper;
        private readonly INotificacionIncapacidadNegocio _notificacionIncapacidad;
        private const string ExchangeNotificacionIncapacidadPagada = "ExchangeNotificacionIncapacidadPagada";

        public NotificacionExpedicionIncapacidadPagada(IConfiguration configuration, IReadTemplateHelper readTemplateHelper, INotificacionIncapacidadNegocio notificacionIncapacidadNegocio)
        {
            _configuration = configuration;
            _readTemplateHelper = readTemplateHelper;
            _notificacionIncapacidad = notificacionIncapacidadNegocio;
            var factory = new ConnectionFactory
            {
                HostName = _configuration["Rabbit:HostName"],
                UserName = _configuration["Rabbit:UserName"],
                Password = _configuration["Rabbit:Password"]
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(ExchangeNotificacionIncapacidadPagada, ExchangeType.Direct);
            _channel.QueueDeclare(BrokerConstant.ExchangeNotificacionIncapacidadPagadaQueueName, false, false, false, null);
            _channel.QueueBind(BrokerConstant.ExchangeNotificacionIncapacidadPagadaQueueName, ExchangeNotificacionIncapacidadPagada, BrokerConstant.ExchangeNotificacionIncapacidadPagadaRouteKey);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                NotificarIncapacidadPagadaDTO notificacion = JsonConvert.DeserializeObject<NotificarIncapacidadPagadaDTO>(content);
                string template = _readTemplateHelper.ReadTemplate(_configuration["NotificacionExpedicionIncapacidadPagada"]);
                _notificacionIncapacidad.NotificacionIncapacidadPagada(notificacion, template);

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume(BrokerConstant.ExchangeNotificacionIncapacidadPagadaQueueName, false, consumer);

            return Task.CompletedTask;
        }
    }
}
