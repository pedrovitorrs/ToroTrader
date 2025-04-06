namespace ToroTrader.Application.Events.Messages
{
    public interface IMessage<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
