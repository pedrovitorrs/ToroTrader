using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroTrader.Application.Domain.Entities;

namespace ToroTrader.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties_WhenValidParametersAreProvided()
        {
            // Arrange
            var bondAsset = "CDB";
            var index = "IPCA";
            var tax = 5.5m;
            var issuerName = "Banco XYZ";
            var unitPrice = 1000m;
            var stock = 50;

            // Act
            var product = new Product(bondAsset, index, tax, issuerName, unitPrice, stock);

            // Assert
            Assert.Equal(bondAsset, product.BondAsset);
            Assert.Equal(index, product.Index);
            Assert.Equal(tax, product.Tax);
            Assert.Equal(issuerName, product.IssuerName);
            Assert.Equal(unitPrice, product.UnitPrice);
            Assert.Equal(stock, product.Stock);
        }

        [Theory]
        [InlineData(null, "IPCA", 5.5, "Banco XYZ", 1000, 50, nameof(Product.BondAsset))]
        [InlineData("CDB", null, 5.5, "Banco XYZ", 1000, 50, nameof(Product.Index))]
        [InlineData("CDB", "IPCA", 5.5, null, 1000, 50, nameof(Product.IssuerName))]
        public void Constructor_ShouldThrowArgumentNullException_WhenRequiredParametersAreNull(
            string bondAsset, string index, decimal tax, string issuerName, decimal unitPrice, int stock, string paramName)
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentNullException>(() => new Product(bondAsset, index, tax, issuerName, unitPrice, stock));
            Assert.Equal(paramName, exception.ParamName);
        }

        [Fact]
        public void DecreaseStock_ShouldReduceStock_WhenQuantityIsValid()
        {
            // Arrange
            var product = new Product("CDB", "IPCA", 5.5m, "Banco XYZ", 1000m, 50);
            var quantityToDecrease = 10;

            // Act
            product.DecreaseStock(quantityToDecrease);

            // Assert
            Assert.Equal(40, product.Stock);
        }

        [Fact]
        public void DecreaseStock_ShouldThrowArgumentException_WhenQuantityIsZeroOrNegative()
        {
            // Arrange
            var product = new Product("CDB", "IPCA", 5.5m, "Banco XYZ", 1000m, 50);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => product.DecreaseStock(0));
            Assert.Throws<ArgumentException>(() => product.DecreaseStock(-5));
        }

        [Fact]
        public void DecreaseStock_ShouldThrowInvalidOperationException_WhenStockIsInsufficient()
        {
            // Arrange
            var product = new Product("CDB", "IPCA", 5.5m, "Banco XYZ", 1000m, 5);
            var quantityToDecrease = 10;

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.DecreaseStock(quantityToDecrease));
        }
    }
}
