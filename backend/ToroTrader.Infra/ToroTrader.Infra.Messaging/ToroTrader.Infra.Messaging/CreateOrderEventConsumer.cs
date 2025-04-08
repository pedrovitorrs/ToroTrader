using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.Extensions.DependencyInjection;
using ToroTrader.Application.Domain.Events;
using ToroTrader.Application.Events.Interfaces;
using ToroTrader.Application.Features.Orders.ProcessOrder;
using ToroTrader.Application.Features.Products.GetProducts;
using ToroTrader.Application.Features.Products.GetProductsTopTraded;

namespace ToroTrader.Infra.Messaging
{
    public class CreateOrderEventConsumer : IEventConsumer<PublisherEvent, Guid>
    {
        private readonly IBus _bus;
        private readonly IServiceProvider _serviceProvider;

        public CreateOrderEventConsumer(IBus bus, IServiceProvider serviceProvider)
        {
            _bus = bus;
            _serviceProvider = serviceProvider;
        }

        public void Subscribe()
        {
            _bus.Subscribe<PublisherEvent>(nameof(PublisherEvent), HandleMessage);
        }

        public void Unsubscribe() => _bus.Dispose();

        protected void HandleMessage(PublisherEvent message)
        {
            try
            {
                using var scope = _serviceProvider.CreateScope();

                var handler = scope.ServiceProvider.GetRequiredService<IProcessOrderUseCase>();

                // Agora o handler e tudo que ele depende estão dentro de um escopo válido
                var topProducts = handler.ExecuteAsync(message)
                       .GetAwaiter()
                       .GetResult();
            }
            catch (Exception ex)
            {
                // Aqui você pode fazer o tratamento de erro que desejar
                Console.WriteLine($"Erro ao processar a mensagem: {ex.Message}");
            }
        }
    }
}
