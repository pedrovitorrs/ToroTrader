using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Events;
using ToroTrader.Application.Domain.Exceptions;
using ToroTrader.Application.Domain.Structure.Repositories;

namespace ToroTrader.Application.Features.Orders.ProcessOrder
{
    public class ProcessOrderUseCase(IRepository<Order> orderRepository, IRepository<User> userRepository, IRepository<Product> productRepository) : IProcessOrderUseCase
    {
        public async Task<object> ExecuteAsync(PublisherEvent request)
        {
            var ordemProcessada = await orderRepository.ExecuteInTransactionAsync(async () =>
            {
                var errors = new List<string>();
                var order = await orderRepository.FirstOrDefaultTrackingAsync(o => o.Id == request.OrderId);

                if (order == null)
                {
                    throw new ValidationException("Ordem não encontrada.");
                }

                var user = await userRepository.FirstOrDefaultTrackingAsync(u => u.Id == order.UserId);

                if (user == null)
                {
                    order.SetError("Usuário não encontrado.");
                    await orderRepository.UpdateAsync(order);
                    return order;
                }

                var product = await productRepository.FirstOrDefaultTrackingAsync(p => p.Id == order.ProductId);

                if (product == null)
                {
                    order.SetError("Produto não encontrado.");
                    await orderRepository.UpdateAsync(order);
                    return order;
                }

                if (product.Stock < order.Quantity)
                {
                    order.SetError("Estoque insuficiente.");
                    await orderRepository.UpdateAsync(order);
                    return order;
                }

                var totalPrice = product.UnitPrice * order.Quantity;

                if (user.Balance < totalPrice)
                {
                    order.SetError("Saldo insuficiente.");
                    await orderRepository.UpdateAsync(order);
                    return order;
                }

                // Debita saldo do usuário e estoque do produto
                user.Debit(totalPrice);
                product.DecreaseStock(order.Quantity);

                order.SetStatus(OrderStatus.Concluido);

                // Atualizações no banco
                await userRepository.UpdateAsync(user);
                await productRepository.UpdateAsync(product);
                await orderRepository.UpdateAsync(order);

                return order;
            });

            return new
            {
                Message = ordemProcessada.Status == OrderStatus.Erro
                ? ordemProcessada.ErrorMessage
                : "Ordem processada com sucesso.",
                OrderId = ordemProcessada.Id,
                Status = ordemProcessada.Status.ToString()
            };
        }

    }
}
