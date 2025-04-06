using ToroTrader.Application.Domain.Entities;

namespace ToroTrader.Application.Domain.Structure.JWT;

public interface ITokenService
{
    Task<(string token, DateTime dateExpiration)> GenerateTokenAsync(User user);

}