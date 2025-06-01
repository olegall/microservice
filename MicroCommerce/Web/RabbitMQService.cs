using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace MicroCommerce.Web
{
    public class RabbitMqService
    {
        public void SendMessage(object obj)
        {
            var message = JsonSerializer.Serialize(obj);
            SendMessage(message);
        }

        public async void SendMessage(string message)
        {
            // Не забудьте вынести значения "localhost" и "MyQueue" в файл конфигурации
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = await factory.CreateConnectionAsync())
            using (var channel = await connection.CreateChannelAsync())
            {
                await channel.QueueDeclareAsync(queue: "MyQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
                var body = Encoding.UTF8.GetBytes(message);
                await channel.BasicPublishAsync(exchange: "", routingKey: "MyQueue", body: body);
            }
        }
    }
}
