using EasyNetQ;
using ToroTrader.Application;
using ToroTrader.Application.Events.Interfaces;

namespace ToroTrader.Infra.Messaging
{
    public class CreateOrderEventPublisher<TMessage> : IEventPublisher<TMessage> where TMessage : class
    {
        private readonly IBus _bus;
        public CreateOrderEventPublisher(IBus bus)
        {
            _bus = bus;
        }

        public async Task Publish(TMessage message)
        {
            await _bus.PublishAsync(message);
        }
    }
}
