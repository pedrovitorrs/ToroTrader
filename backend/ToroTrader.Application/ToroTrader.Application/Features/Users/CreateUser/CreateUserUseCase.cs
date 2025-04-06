using System.Xml.Linq;
using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Structure.JWT;
using ToroTrader.Application.Domain.Structure.Repositories;

namespace ToroTrader.Application.Features.Users.CreateUser;

public class CreateUserUseCase(
    ITokenService tokenService,
    IRepository<User> userRepository) : ICreateUserUseCase
{
    public async Task<object> ExecuteAsync(CreateUserRequest request)
    {
        var user = new User(name: request.Name,
            balance: request.Balance, 
            documentNumber: request.DocumentNumber);

        await userRepository.CreateAsync(user);

        var retorno = await tokenService.GenerateTokenAsync(user);

        return new
        {
            accessToken = retorno.token,
            expiresIn = retorno.dateExpiration
        };
    }
}
