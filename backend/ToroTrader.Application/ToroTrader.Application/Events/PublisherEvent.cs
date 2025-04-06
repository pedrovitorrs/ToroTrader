using ToroTrader.Application.Events.Messages;

namespace ToroTrader.Application.Domain.Events
{
    public class PublisherEvent : Message
    {
        public string Name { get; set; }
    }
}
