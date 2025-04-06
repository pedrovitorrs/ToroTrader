using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Structure.Repositories;


namespace ToroTrader.Application.Features.Orders.CreateOrder
{
    public class CreateOrderUseCase(IRepository<Order> orderRepository) : ICreateOrderUseCase
    {
        public async Task<object> ExecuteAsync(string userId, CreateOrderRequest request)
        {
            var user = new Order(userId: Guid.Parse(userId),
                productId: Guid.Parse(request.ProductId),
                quantity: request.Quantity);

            var order = await orderRepository.CreateAsync(user);

            return order;
        }
    }
}
