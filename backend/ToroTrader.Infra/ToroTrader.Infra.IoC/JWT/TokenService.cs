using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Structure.JWT;

namespace ToroTrader.Infra.IoC.JWT;

public class TokenService(IConfiguration configuration) : ITokenService
{
    public Task<(string token, DateTime dateExpiration)> GenerateTokenAsync(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]?.ToString() ?? throw new ArgumentNullException("Jwt:Key"));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim("User.Name", user.Name),
                new Claim("User.AccountId", user.AccountId),
                new Claim("User.ClientId", user.ClientId),
                new Claim("User.Id", user.Id.ToString()),
                new Claim("User.DocumentNumber", user.DocumentNumber.ToString()),
            }),
            Expires = DateTime.UtcNow.AddMinutes(int.Parse(configuration["Jwt:ExpireInMinutes"]?.ToString())),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
        };
        /// tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, permissao?.Nome));
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return Task.FromResult(result: 
            (tokenHandler.WriteToken(token),
            DateTime.Now.AddMinutes(int.Parse(configuration["Jwt:ExpireInMinutes"]?.ToString()))));
    }
}
