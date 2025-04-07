using System.Linq.Expressions;
using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Structure.Repositories;

namespace ToroTrader.Application.Features.Orders.GetOrdersByUser
{
    public class GetOrdersByUserHandler(IRepository<Order> orderRepository) : IGetOrdersByUserHandler
    {
        public async Task<GetOrdersByUsersResponse> HandleAsync(string userId, GetOrdersByUserQuery request)
        {
            var userGuid = Guid.Parse(userId);

            var pagedResult = await orderRepository.ToListAsync(
                pageNumber: request.pageNumber,
                pageSize: request.pageSize,
                predicate: p => p.UserId == userGuid,
                includes: [
                    o => o.Product,
                    o => o.User
                ]
            );

            var items = pagedResult.Items.Select(order => new GetOrdersByUserResponse
            {
                Id = order.Id,
                BondAsset = order.Product.BondAsset,
                Index = order.Product.Index,
                Quantity = order.Quantity,
                Status = order.Status.ToString(),
                UnitPrice = order.Product.UnitPrice
            }).ToList();

            return new GetOrdersByUsersResponse
            {
                Items = items,
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalElements = pagedResult.TotalElements
            };
        }

    }


}
