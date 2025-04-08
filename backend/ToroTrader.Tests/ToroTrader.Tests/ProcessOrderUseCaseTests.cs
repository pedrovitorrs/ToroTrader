using Moq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Events;
using ToroTrader.Application.Domain.Structure.Repositories;
using ToroTrader.Application.Features.Orders.ProcessOrder;
using Xunit;

public class ProcessOrderUseCaseTests
{
    [Fact]
    public async Task ExecuteAsync_ShouldProcessOrder_WhenDataIsValid()
    {
        // Arrange
        var orderId = Guid.NewGuid();
        var userId = Guid.NewGuid();
        var productId = Guid.NewGuid();

        var order = new Order(userId, productId, 2) { Id = orderId };
        var user = new User("John Doe", 1000m, "12345678900") { Id = userId };
        var product = new Product("CDB", "IPCA", 10m, "Banco XP", 100m, 10) { Id = productId };

        var mockOrderRepo = new Mock<IRepository<Order>>();
        var mockUserRepo = new Mock<IRepository<User>>();
        var mockProductRepo = new Mock<IRepository<Product>>();

        mockOrderRepo
            .Setup(r => r.FirstOrDefaultTrackingAsync(It.IsAny<Expression<Func<Order, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Expression<Func<Order, bool>> predicate, CancellationToken _) =>
            {
                return predicate.Compile().Invoke(order) ? order : null;
            });

        mockUserRepo
            .Setup(r => r.FirstOrDefaultTrackingAsync(It.IsAny<Expression<Func<User, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Expression<Func<User, bool>> predicate, CancellationToken _) =>
            {
                return predicate.Compile().Invoke(user) ? user : null;
            });

        mockProductRepo
            .Setup(r => r.FirstOrDefaultTrackingAsync(It.IsAny<Expression<Func<Product, bool>>>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync((Expression<Func<Product, bool>> predicate, CancellationToken _) =>
            {
                return predicate.Compile().Invoke(product) ? product : null;
            });

        var useCase = new ProcessOrderUseCase(mockOrderRepo.Object, mockUserRepo.Object, mockProductRepo.Object);

        var evt = new PublisherEvent { OrderId = orderId, UserId = userId, ProductId = productId, Quantity = 2 };

        // Act
        var result = await useCase.ExecuteAsync(evt);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Concluido", order.Status.ToString());
        mockUserRepo.Verify(r => r.UpdateAsync(It.Is<User>(u => u.Id == user.Id), It.IsAny<CancellationToken>()), Times.Once);
        mockProductRepo.Verify(r => r.UpdateAsync(It.Is<Product>(p => p.Id == product.Id), It.IsAny<CancellationToken>()), Times.Once);
        mockOrderRepo.Verify(r => r.UpdateAsync(It.Is<Order>(o => o.Id == order.Id), It.IsAny<CancellationToken>()), Times.Once);
    }

}
