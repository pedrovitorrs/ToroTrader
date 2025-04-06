using System;
using EasyNetQ;
using ToroTrader.Application.Domain.Events;
using ToroTrader.Application.Events.Interfaces;

namespace ToroTrader.Infra.Messaging
{
    public class ConsumerSubscriptions : IConsumerSubscriptions
    {
        private readonly IEventConsumer<PublisherEvent, Guid> _createOrderEventConsumer;
        private readonly IBus _bus;

        public ConsumerSubscriptions(IEventConsumer<PublisherEvent, Guid> deleteBookEventConsumer, IBus bus)
        {
            _createOrderEventConsumer = deleteBookEventConsumer;
            _bus = bus;
        }

        public void Subscribe()
        {
            _createOrderEventConsumer.Subscribe();
        }

        public void Unsubscribe()
        {
            _createOrderEventConsumer.Unsubscribe();
        }
    }

    public interface IConsumerSubscriptions
    {
        void Subscribe();
        void Unsubscribe();
    }
}
