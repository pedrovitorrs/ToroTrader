
namespace ToroTrader.Application.Features.Users.CreateUser
{
    public interface ICreateUserUseCase
    {
        Task<object> ExecuteAsync(CreateUserRequest request);
    }
}