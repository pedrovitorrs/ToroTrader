using ToroTrader.Application.Domain.Events;

namespace ToroTrader.Application.Features.Orders.ProcessOrder
{
    public interface IProcessOrderUseCase
    {
        Task<object> ExecuteAsync(PublisherEvent request);
    }
}
