using System;
using System.Threading.Tasks;
using Moq;
using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Features.Orders.CreateOrder;
using ToroTrader.Application.Domain.Structure.Repositories;
using Xunit;
using ToroTrader.Application.Domain.Events;
using ToroTrader.Application.Events.Interfaces;

namespace ToroTrader.Tests
{
    public class CreateOrderUseCaseTests
    {
        [Fact]
        public async Task ExecuteAsync_ShouldCreateOrder_WhenValidRequestIsProvided()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Order>>();
            var mockEvent = new Mock<IEventPublisher<PublisherEvent>>();
            var useCase = new CreateOrderUseCase(mockRepository.Object, mockEvent.Object);
            var guid = Guid.NewGuid().ToString();
            var userId = Guid.NewGuid().ToString();
            var request = new CreateOrderRequest
            {
                ProductId = guid,
                Quantity = 10
            };

            var fakeOrder = new Order(Guid.Parse(userId), Guid.Parse(guid), 10);
            mockRepository.Setup(r => r.CreateAsync(It.IsAny<Order>(), default))
                          .ReturnsAsync(fakeOrder);

            // Act
            var result = await useCase.ExecuteAsync(userId, request);

            // Assert
            Assert.NotNull(result);
            mockRepository.Verify(r => r.CreateAsync(It.IsAny<Order>(), default), Times.Once);

            mockEvent.Verify(p => p.Publish(It.Is<PublisherEvent>(e =>
                e.Quantity == request.Quantity &&
                e.UserId == Guid.Parse(userId) &&
                e.ProductId == Guid.Parse(request.ProductId)
            )), Times.Once);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public async Task ExecuteAsync_ShouldThrow_WhenQuantityIsInvalid(int quantity)
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Order>>();
            var mockEvent = new Mock<IEventPublisher<PublisherEvent>>();
            var useCase = new CreateOrderUseCase(mockRepository.Object, mockEvent.Object);

            var request = new CreateOrderRequest
            {
                ProductId = Guid.NewGuid().ToString(),
                Quantity = quantity
            };

            var userId = Guid.NewGuid().ToString();

            // Act & Assert
            await Assert.ThrowsAsync<System.ArgumentNullException>(() => useCase.ExecuteAsync(userId, request));
        }

    }
}
