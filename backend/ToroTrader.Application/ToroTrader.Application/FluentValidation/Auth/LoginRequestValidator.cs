using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ToroTrader.Application.Features.Auth.Login;

namespace ToroTrader.Application.FluentValidation.Auth
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.accountId)
                .NotEmpty().WithMessage("accountId is required.");

            RuleFor(x => x.clientId).
                NotEmpty().WithMessage("clientId is required.");
        }
    }
}
