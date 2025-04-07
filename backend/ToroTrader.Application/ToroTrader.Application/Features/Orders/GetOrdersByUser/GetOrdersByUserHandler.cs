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
                ],
                orderBy: u => u.OrderByDescending(p => p.Id)
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

            var user = new GetOrdersByUser {
                UserId = pagedResult.Items?.FirstOrDefault()?.UserId ?? Guid.Empty,
                AccountId = pagedResult.Items?.FirstOrDefault()?.User?.AccountId,
                ClientId = pagedResult.Items?.FirstOrDefault()?.User?.ClientId,
                Balance = pagedResult.Items?.FirstOrDefault()?.User?.Balance ?? 0,
                DocumentNumber = pagedResult.Items?.FirstOrDefault()?.User?.DocumentNumber
            };

            return new GetOrdersByUsersResponse
            {
                Items = items,
                User = user,
                PageNumber = pagedResult.PageNumber,
                PageSize = pagedResult.PageSize,
                TotalElements = pagedResult.TotalElements
            };
        }

    }


}
