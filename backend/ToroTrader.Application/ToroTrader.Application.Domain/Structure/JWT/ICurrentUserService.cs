using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToroTrader.Application.Domain.Structure.JWT
{
    public interface ICurrentUserService
    {
        string UserId { get; }
        string AccountId { get; }
    }
}
