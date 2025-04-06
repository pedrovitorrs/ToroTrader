namespace ToroTrader.Application.Features.Orders.CreateOrder
{
    public interface ICreateOrderUseCase
    {
        Task<object> ExecuteAsync(string userId, CreateOrderRequest request);
    }
}
