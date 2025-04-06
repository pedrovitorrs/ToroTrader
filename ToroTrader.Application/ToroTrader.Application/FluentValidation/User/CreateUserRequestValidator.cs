using FluentValidation;
using ToroTrader.Application.Features.Users.CreateUser;
namespace ToroTrader.Infra.IoC.FluentValidation.User
{

    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.DocumentNumber)
                .NotEmpty().WithMessage("DocumentNumber is required.");

            RuleFor(x => x.Balance)
                .GreaterThanOrEqualTo(0).WithMessage("Balance must be zero or greater.");
        }
    }
}
