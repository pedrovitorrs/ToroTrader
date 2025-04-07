using Microsoft.AspNetCore.Mvc.RazorPages;
using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Structure.Pagination;
using ToroTrader.Application.Domain.Structure.Repositories;

namespace ToroTrader.Application.Features.Products.GetProducts
{
    public class GetProductsHandler(IRepository<Product> productRepository) : IGetProductsHandler
    {
        public async Task<object> HandleAsync(GetProductsQuery request)
        {
            var pagedResult = await productRepository.ToListAsync(
                pageNumber: request.pageNumber,
                pageSize: request.pageSize,
                predicate: u => string.IsNullOrEmpty(request.BondAsset) || u.BondAsset.Contains(request.BondAsset),
                orderBy: u => u.OrderByDescending(p => p.Tax)
            );

            return pagedResult;
        }
    }
}
