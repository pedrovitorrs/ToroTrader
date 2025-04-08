using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroTrader.Application.Domain.Entities;

namespace ToroTrader.Tests
{
    public class OrderTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties_WhenValidParametersAreProvided()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var quantity = 10;

            // Act
            var order = new Order(userId, productId, quantity);

            // Assert
            Assert.Equal(userId, order.UserId);
            Assert.Equal(productId, order.ProductId);
            Assert.Equal(quantity, order.Quantity);
            Assert.Equal(OrderStatus.Pendente, order.Status);
            Assert.Null(order.ErrorMessage);
        }

        [Fact]
        public void Constructor_ShouldThrowArgumentNullException_WhenQuantityIsZeroOrNegative()
        {
            // Arrange
            var userId = Guid.NewGuid();
            var productId = Guid.NewGuid();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Order(userId, productId, 0));
            Assert.Throws<ArgumentNullException>(() => new Order(userId, productId, -5));
        }

        [Fact]
        public void SetError_ShouldUpdateStatusToErro_AndSetErrorMessage()
        {
            // Arrange
            var order = new Order(Guid.NewGuid(), Guid.NewGuid(), 10);
            var errorMessage = "An error occurred";

            // Act
            order.SetError(errorMessage);

            // Assert
            Assert.Equal(OrderStatus.Erro, order.Status);
            Assert.Equal(errorMessage, order.ErrorMessage);
        }

        [Fact]
        public void SetStatus_ShouldUpdateStatus_WhenCalled()
        {
            // Arrange
            var order = new Order(Guid.NewGuid(), Guid.NewGuid(), 10);

            // Act
            order.SetStatus(OrderStatus.Concluido);

            // Assert
            Assert.Equal(OrderStatus.Concluido, order.Status);
        }
    }
}
