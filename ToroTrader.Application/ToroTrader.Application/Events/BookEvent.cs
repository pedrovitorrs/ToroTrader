using ToroTrader.Application.Domain.Events;
using ToroTrader.Application.Events.Messages;

namespace ToroTrader.Application.Events
{
    public class BookEvent : Message
    {
        public string Title { get; set; }
        public virtual PublisherEvent Publisher { get; set; }
    }
}
