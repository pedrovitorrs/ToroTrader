namespace ToroTrader.Application.Features.Orders.GetOrdersByUser
{
    public interface IGetOrdersByUserHandler
    {
        Task<GetOrdersByUsersResponse> HandleAsync(string userId, GetOrdersByUserQuery request);
    }
}
