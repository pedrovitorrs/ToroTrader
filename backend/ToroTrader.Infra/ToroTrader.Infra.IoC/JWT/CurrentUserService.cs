using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using ToroTrader.Application.Domain.Structure.JWT;

namespace ToroTrader.Infra.IoC.JWT
{
    public class CurrentUserService : ICurrentUserService
    {
        public string Name { get; }
        public string UserId { get; }
        public string AccountId { get; }
        public string ClientId { get; }

        public CurrentUserService(IHttpContextAccessor accessor)
        {
            var user = accessor.HttpContext?.User;

            if (user?.Identity?.IsAuthenticated == true)
            {
                Name = user.FindFirst("User.Name")?.Value;
                AccountId = user.FindFirst("User.AccountId")?.Value;
                ClientId = user.FindFirst("User.ClientId")?.Value;
                UserId = user.FindFirst("User.Id")?.Value;
            }
        }
    }
}
