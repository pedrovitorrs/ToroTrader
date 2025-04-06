using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToroTrader.Application.Features.Users.CreateUser;

namespace ToroTrader.Application.Features.Products.GetProducts
{
    public interface IGetProductsHandler
    {
        Task<object> HandleAsync(GetProductsQuery request);
    }
}
