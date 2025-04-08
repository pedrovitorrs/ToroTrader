namespace ToroTrader.Application.Events.Interfaces
{
    public interface IEventPublisher<in TMessage> where TMessage : class
    {
        Task Publish(TMessage message);
    }
}
