using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Structure.Repositories;
using ToroTrader.Application.Events.Interfaces;
using ToroTrader.Application.Events;
using ToroTrader.Application.Domain.Events;


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

            orderService.Publish(new PublisherEvent() { Name = "teste" });

            return order;
        }
    }
}
