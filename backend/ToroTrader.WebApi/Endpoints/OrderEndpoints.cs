using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ToroTrader.Application.Domain.Structure.JWT;
using ToroTrader.Application.Features.Orders.CreateOrder;

namespace ToroTrader.WebApi.Endpoints
{
    public static class OrderEndpoints
    {
        public static IEndpointRouteBuilder AddOrderEndpoints(this IEndpointRouteBuilder app, string route, string tag)
        {
            var ordergroup = app.MapGroup(route).WithTags(tag);

            ordergroup.MapPost(string.Empty,
                async ([FromServices] ICreateOrderUseCase useCase, [FromBody] CreateOrderRequest request, [FromServices] ICurrentUserService currentUser, IValidator<CreateOrderRequest> validator) =>
                {
                    var validationResult = await validator.ValidateAsync(request);

                    if (!validationResult.IsValid)
                        return Results.BadRequest(validationResult.Errors);

                    var retorno = await useCase.ExecuteAsync(currentUser.UserId, request);

                    return Results.Ok(retorno);
                })
                .RequireAuthorization()
                .Produces<object>(StatusCodes.Status200OK);

            return app;
        }
    }
}
