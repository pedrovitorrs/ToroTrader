using ToroTrader.Application.Events.Messages;

namespace ToroTrader.Application.Events.Interfaces
{
    public interface IEventConsumer<TMessage, TPrimaryKey>
        where TMessage : class, IMessage<TPrimaryKey>
    {
        void Subscribe();
        void Unsubscribe();
    }
}
