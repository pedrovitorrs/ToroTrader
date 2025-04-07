using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Structure.Repositories;

namespace ToroTrader.Application.Features.Products.GetProductsTopTraded
{
    public class GetProductsTopTradedHandler(IRepository<Product> productRepository, IRepository<Order> orderRepository) : IGetProductsTopTradedHandler
    {
        public async Task<object> HandleAsync(GetProductsTopTradedQuery request)
        {
            // Agrupa as orders e pega os 5 ProductIds mais negociados
            var topProductIds = orderRepository.AsQueriable()
                .GroupBy(o => o.ProductId)
                .Select(g => new
                {
                    ProductId = g.Key,
                    TotalQuantity = g.Sum(x => x.Quantity)
                })
                .OrderByDescending(x => x.TotalQuantity)
                .Take(5)
                .Select(x => x.ProductId)
                .ToList();

            // Consulta os produtos com base nesses IDs e aplica filtro e paginação
            var pagedResult = await productRepository.ToListAsync(
                pageNumber: request.pageNumber,
                pageSize: request.pageSize,
                predicate: p =>
                    topProductIds.Contains(p.Id),
                orderBy: u => u.OrderByDescending(p => p.Tax)
            );

            return pagedResult;
        }
    }
}
