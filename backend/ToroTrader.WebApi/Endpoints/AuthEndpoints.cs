using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ToroTrader.Application.Features.Auth.Login;
using ToroTrader.Application.Features.Users.CreateUser;

namespace ToroTrader.WebApi.Endpoints
{
    public static class AuthEndpoints
    {
        public static IEndpointRouteBuilder AddAuthEndpoints(this IEndpointRouteBuilder app, string route, string tag)
        {
            var authgroup = app.MapGroup(route).WithTags(tag);

            authgroup.MapPost(string.Empty,
                async ([FromServices] ILoginUseCase useCase, [FromBody] LoginRequest request, IValidator<LoginRequest> validator) =>
                {
                    var validationResult = await validator.ValidateAsync(request);

                    if (!validationResult.IsValid)
                        return Results.BadRequest(validationResult.Errors);

                    var retorno = await useCase.ExecuteAsync(request);

                    return Results.Ok(retorno);
                })
                .AllowAnonymous()
                .Produces<object>(StatusCodes.Status200OK);

            return app;
        }
    }
}
