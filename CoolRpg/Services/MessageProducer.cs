using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace CoolRpg.Services
{
    public class MessageProducer : IMessageProducer
    {
        public void SendingMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "rabbitmq",// "localhost"
                UserName = "guest",
                Password = "guest",
                VirtualHost = "/"
            };

            var conn = factory.CreateConnection();

            using var chanel = conn.CreateModel();

            chanel.QueueDeclare("npc", exclusive: false);

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            chanel.BasicPublish("", "npc", body: body);
        }
    }
}
