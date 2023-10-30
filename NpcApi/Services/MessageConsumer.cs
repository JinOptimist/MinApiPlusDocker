using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace NpcApi.Services
{
    public class MessageConsumer : IMessageConsumer
    {
        private IConnection _connection;
        private IModel _chanel;
        public void StartListening()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "rabbitmq",//"localhost"
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"
            };

            _connection = factory.CreateConnection();

            _chanel = _connection.CreateModel();

            _chanel.QueueDeclare("npc", exclusive: false);

            var consumer = new EventingBasicConsumer(_chanel);

            consumer.Received += (model, eventArgs) =>
            {
                var bodyArray = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(bodyArray);
                Console.WriteLine($"message getted = {message}");
            };

            _chanel.BasicConsume("npc", true, consumer);
        }

        public void StopListening()
        {
            _connection.Close();
            _chanel.Dispose();
        }
    }
}
