using System.Text;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using DevTrackR.ShippingOrders.Core.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DevTrackR.ShippingOrders.Applicaton.Subscribers {
    public class ShippingOrderCompletedSubscriber : BackgroundService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private const string Queue = "shipping-orders-service/shipping-order-completed";
        private const string RoutingKeySubscribe = "shipping-order-completed";
        private readonly IServiceProvider _serviceProvider;
        private const string TrackingsExchange = "trackings-service";
 
        public ShippingOrderCompletedSubscriber(IServiceProvider serviceProvider)
        {
            var connectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };
 
            _connection = connectionFactory.CreateConnection("shipping-order-completed-consumer");
 
            _channel = _connection.CreateModel();
 
            _channel.QueueDeclare(
                queue: Queue,
                durable: true,
                exclusive: false,
                autoDelete: false);
 
            _channel.QueueBind(Queue, TrackingsExchange, RoutingKeySubscribe);
 
            _serviceProvider = serviceProvider;
        }
 
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);
 
            consumer.Received += async (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var @event = JsonConvert.DeserializeObject<ShippingOrderIsCompletedEvent>(contentString);
 
                Console.WriteLine($"Message ShippingOrderIsCompletedEvent received with Code {@event.TrackingCode}");
 
                Complete(@event).Wait();
 
                _channel.BasicAck(eventArgs.DeliveryTag, false);
            };
 
            _channel.BasicConsume(Queue, false, consumer);
 
            return Task.CompletedTask;
        }
 
        public async Task Complete(ShippingOrderIsCompletedEvent @event)
        {
            using var scope = _serviceProvider.CreateScope();
 
            var repository = scope.ServiceProvider.GetRequiredService<IShippingOrderRepository>();
 
            var shippingOrder = await repository.GetByCodeAsync(@event.TrackingCode);
 
            shippingOrder.SetCompleted();
 
            await repository.UpdateAsync(shippingOrder);
        }
    }
 
    public class ShippingOrderIsCompletedEvent
    {
        public string TrackingCode { get; set; }
    }

}