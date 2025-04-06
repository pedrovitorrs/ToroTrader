using System.ComponentModel;

namespace ToroTrader.Application.Features.Auth.Login
{
    public class LoginRequest
    {
        [DefaultValue("00001")]
        public string accountId { get; set; }

        [DefaultValue("12454")]
        public string clientId { get; set; }
    }
}
