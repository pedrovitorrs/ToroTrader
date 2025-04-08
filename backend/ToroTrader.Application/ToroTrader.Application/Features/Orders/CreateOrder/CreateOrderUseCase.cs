using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Events;
using ToroTrader.Application.Domain.Structure.Repositories;
using ToroTrader.Application.Events.Interfaces;


namespace ToroTrader.Application.Features.Orders.CreateOrder
{
    public class CreateOrderUseCase(IRepository<Order> orderRepository, IEventPublisher<PublisherEvent> orderService) : ICreateOrderUseCase
    {
        public async Task<object> ExecuteAsync(string userId, CreateOrderRequest request)
        {
            var user = new Order(userId: Guid.Parse(userId),
                productId: Guid.Parse(request.ProductId),
                quantity: request.Quantity);

            var order = await orderRepository.CreateAsync(user);

            await orderService.Publish(new PublisherEvent() { Quantity = request.Quantity, UserId = Guid.Parse(userId), ProductId = Guid.Parse(request.ProductId), OrderId = order.Id });

            return order;
        }
    }
}
