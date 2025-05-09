﻿using LibreriasIncapacidades.Modelos.Constants;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NegocioIncapacidades
{
    public class AnularIncapacidadProducerNegocio : IAnularIncapacidadProducerNegocio
    {
        private readonly IConfiguration _configuration;

        public AnularIncapacidadProducerNegocio(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Enviar mensaje
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        public void SendNotificationAnularIncapacidadMessage<T>(T message)
        {
            //Here we specify the Rabbit MQ Server. we use rabbitmq docker image and use it
            var factory = new ConnectionFactory
            {
                HostName = _configuration["Rabbit:HostName"],
                UserName = _configuration["Rabbit:UserName"],
                Password = _configuration["Rabbit:Password"]
            };
            //Create the RabbitMQ connection using connection factory details as i mentioned above
            var connection = factory.CreateConnection();
            //Here we create channel with session and model
            using
            var channel = connection.CreateModel();
            //declare the queue after mentioning name and a few property related to that
            channel.QueueDeclare(BrokerConstant.ExchangeNotificacionIncapacidadAnuladaQueueName, durable: false, autoDelete: false, exclusive: false);
            //Serialize the message
            var json = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(json);
            //put the data on to the product queue
            channel.BasicPublish(exchange: BrokerConstant.ExchangeNotificacionIncapacidadAnulada, routingKey: BrokerConstant.ExchangeNotificacionIncapacidadAnuladaRouteKey, body: body);
        }

    }
}
