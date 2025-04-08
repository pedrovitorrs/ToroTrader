using ToroTrader.Application.Events.Messages;

namespace ToroTrader.Application.Domain.Events
{
    public class PublisherEvent : Message
    {
        public int Quantity { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public Guid OrderId { get; set; }
    }
}
