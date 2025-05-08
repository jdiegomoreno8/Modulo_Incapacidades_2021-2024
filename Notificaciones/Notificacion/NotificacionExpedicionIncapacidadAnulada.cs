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
    public class NotificacionExpedicionIncapacidadAnulada : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;
        private IConfiguration _configuration;
        private readonly IReadTemplateHelper _readTemplateHelper;
        private readonly INotificacionIncapacidadNegocio _notificacionIncapacidad;
        private const string ExchangeNotificacionIncapacidadAnulada = "ExchangeNotificacionIncapacidadAnulada";

        public NotificacionExpedicionIncapacidadAnulada(IConfiguration configuration, IReadTemplateHelper readTemplateHelper, INotificacionIncapacidadNegocio notificacionIncapacidad)
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

            _channel.ExchangeDeclare(ExchangeNotificacionIncapacidadAnulada, ExchangeType.Direct);
            _channel.QueueDeclare(BrokerConstant.ExchangeNotificacionIncapacidadAnuladaQueueName, false, false, false, null);
            _channel.QueueBind(BrokerConstant.ExchangeNotificacionIncapacidadAnuladaQueueName, ExchangeNotificacionIncapacidadAnulada, BrokerConstant.ExchangeNotificacionIncapacidadAnuladaRouteKey);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var content = Encoding.UTF8.GetString(ea.Body.ToArray());
                NotificarIncapacidadDTO notificacion = JsonConvert.DeserializeObject<NotificarIncapacidadDTO>(content);
                string templateAdministradora = _readTemplateHelper.ReadTemplate(_configuration["NotificacionExpedicionIncapacidadAnuladaEPSARL"]);
                string templateEmpleador = _readTemplateHelper.ReadTemplate(_configuration["NotificacionExpedicionIncapacidadAnuladaEmpleador"]);
                string templateAFP = _readTemplateHelper.ReadTemplate(_configuration["NotificacionExpedicionIncapacidadAnuladaAFP"]);
                _notificacionIncapacidad.NotificacionIncapacidadAnulada(notificacion, templateAdministradora, templateEmpleador, templateAFP);

                _channel.BasicAck(ea.DeliveryTag, false);
            };
            _channel.BasicConsume(BrokerConstant.ExchangeNotificacionIncapacidadAnuladaQueueName, false, consumer);

            return Task.CompletedTask;
        }
    }
}
