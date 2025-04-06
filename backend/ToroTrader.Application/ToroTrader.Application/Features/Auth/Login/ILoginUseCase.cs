
using ToroTrader.Application.Features.Auth.Login;

namespace ToroTrader.Application.Features.Users.CreateUser
{
    public interface ILoginUseCase
    {
        Task<object> ExecuteAsync(LoginRequest request);
    }
}