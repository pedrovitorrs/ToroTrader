using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroTrader.Application.Features.Users.CreateUser;

namespace ToroTrader.Application.Features.Products.GetProductsTopTraded
{
    public interface IGetProductsTopTradedHandler
    {
        Task<object> HandleAsync(GetProductsTopTradedQuery request);
    }
}
