using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using ToroTrader.Application.Features.Orders.CreateOrder;
using ToroTrader.Application.Features.Users.CreateUser;

namespace ToroTrader.Application.FluentValidation.Order
{
    public class CreateOrderRequestValidator : AbstractValidator<CreateOrderRequest>
    {
        public CreateOrderRequestValidator()
        {
            RuleFor(x => x.ProductId)
                .NotEmpty().WithMessage("Name is required.");

            RuleFor(x => x.Quantity)
                .GreaterThanOrEqualTo(0).WithMessage("Quantity must be zero or greater.");
        }
    }
}
