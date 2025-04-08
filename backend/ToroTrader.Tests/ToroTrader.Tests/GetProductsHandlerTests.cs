using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Moq;
using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Structure.Pagination;
using ToroTrader.Application.Domain.Structure.Repositories;
using ToroTrader.Application.Features.Products.GetProducts;
using Xunit;

namespace ToroTrader.Tests
{
    public class GetProductsHandlerTests
    {
        [Fact]
        public async Task HandleAsync_ShouldReturnPagedResult_WhenValidRequestIsProvided()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Product>>();
            var handler = new GetProductsHandler(mockRepository.Object);

            var request = new GetProductsQuery
            {
                pageNumber = 1,
                pageSize = 10,
                BondAsset = null
            };

            var products = new List<Product>
            {
                new Product("CDB", "IPCA", 5.5m, "Banco XYZ", 1000m, 50),
                new Product("LCI", "CDI", 4.5m, "Banco ABC", 500m, 30)
            };

            var pagedResult = new PagedResult<Product>(products, 1, 10, products.Count);

            mockRepository
                .Setup(r => r.ToListAsync(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<Expression<Func<Product, bool>>>(),
                    It.IsAny<Func<IQueryable<Product>, IOrderedQueryable<Product>>>(),
                    null))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await handler.HandleAsync(request);

            // Assert
            Assert.NotNull(result);
            var resultPaged = Assert.IsType<PagedResult<Product>>(result);
            Assert.Equal(2, resultPaged.Items.Count);
        }

        [Fact]
        public async Task HandleAsync_ShouldFilterByBondAsset_WhenBondAssetIsProvided()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Product>>();
            var handler = new GetProductsHandler(mockRepository.Object);

            var request = new GetProductsQuery
            {
                pageNumber = 1,
                pageSize = 10,
                BondAsset = "CDB"
            };

            var products = new List<Product>
            {
                new Product("CDB", "IPCA", 5.5m, "Banco XYZ", 1000m, 50)
            };

            var pagedResult = new PagedResult<Product>(products, 1, 10, products.Count);

            mockRepository
                .Setup(r => r.ToListAsync(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.Is<Expression<Func<Product, bool>>>(predicate => predicate.Compile()(products[0])),
                    It.IsAny<Func<IQueryable<Product>, IOrderedQueryable<Product>>>(),
                    null))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await handler.HandleAsync(request);

            // Assert
            Assert.NotNull(result);
            var resultPaged = Assert.IsType<PagedResult<Product>>(result);
            Assert.Single(resultPaged.Items);
            Assert.Equal("CDB", resultPaged.Items.First().BondAsset);
        }

        [Fact]
        public async Task HandleAsync_ShouldOrderByTaxDescending_WhenCalled()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Product>>();
            var handler = new GetProductsHandler(mockRepository.Object);

            var request = new GetProductsQuery
            {
                pageNumber = 1,
                pageSize = 10,
                BondAsset = null
            };

            var products = new List<Product>
            {
                new Product("CDB", "IPCA", 5.5m, "Banco XYZ", 1000m, 50),
                new Product("LCI", "CDI", 4.5m, "Banco ABC", 500m, 30)
            };

            var pagedResult = new PagedResult<Product>(products.OrderByDescending(p => p.Tax).ToList(), 1, 10, products.Count);

            mockRepository
                .Setup(r => r.ToListAsync(
                    It.IsAny<int>(),
                    It.IsAny<int>(),
                    It.IsAny<Expression<Func<Product, bool>>>(),
                    It.Is<Func<IQueryable<Product>, IOrderedQueryable<Product>>>(orderBy => orderBy(products.AsQueryable()).First().Tax == 5.5m),
                    null))
                .ReturnsAsync(pagedResult);

            // Act
            var result = await handler.HandleAsync(request);

            // Assert
            Assert.NotNull(result);
            var resultPaged = Assert.IsType<PagedResult<Product>>(result);
            Assert.Equal(5.5m, resultPaged.Items.First().Tax);
        }
    }
}