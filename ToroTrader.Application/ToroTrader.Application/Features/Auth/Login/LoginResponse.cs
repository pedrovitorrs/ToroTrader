using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
