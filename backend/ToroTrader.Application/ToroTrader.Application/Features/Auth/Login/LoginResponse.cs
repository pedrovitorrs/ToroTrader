namespace ToroTrader.Application.Features.Auth.Login
{
    public class LoginResponse
    {
        public string accessToken { get; set; }
        public DateTime expiresIn { get; set; }
    }
}
