using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ToroTrader.Application.Features.Auth.Login
{
    public class LoginResponse
    {
        public string accessToken { get; set; }
        public DateTime expiresIn { get; set; }
    }
}
