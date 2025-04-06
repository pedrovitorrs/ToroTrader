using Microsoft.AspNetCore.Mvc;
using ToroTrader.Application.Domain.Entities;
using ToroTrader.Application.Domain.Structure.JWT;
using ToroTrader.Application.Domain.Structure.Repositories;
using ToroTrader.Application.Features.Users.CreateUser;

namespace ToroTrader.Application.Features.Auth.Login
{
    public class LoginUseCase(
        ITokenService tokenService,
        IRepository<User> userRepository) : ILoginUseCase
    {
        public async Task<object> ExecuteAsync(LoginRequest request)
        {
            var user = await userRepository.FirstOrDefaultTrackingAsync(user => user.AccountId == request.accountId && user.ClientId == request.clientId);

            if (user == null || string.IsNullOrEmpty(user.Id.ToString()))
            {
                throw new Exception("Usuário não encontrado ou ID do usuário inválido.");
            }

            var retorno = await tokenService.GenerateTokenAsync(user);

            return new LoginResponse
            {
                accessToken = retorno.token,
                expiresIn = retorno.dateExpiration
            };
        }
    }
}
