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

        public void Publish(TMessage message)
        {
            _bus.Publish(message);
        }
    }
}
