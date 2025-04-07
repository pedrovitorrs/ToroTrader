using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using ToroTrader.Application.Features.Users.CreateUser;

namespace ToroTrader.WebApi.Endpoints;

public static class UserEnpoints
{
    public static IEndpointRouteBuilder AddUserEndpoints(this IEndpointRouteBuilder app, string route, string tag)
    {
        var usergroup = app.MapGroup(route).WithTags(tag);

        usergroup.MapGet("{id}",
            ([FromServices] ICreateUserUseCase useCase, [FromRoute] string id) =>
            {
                return Results.Ok(null);
            })
            .AllowAnonymous()
            .Produces<object>(StatusCodes.Status200OK);

        usergroup.MapGet("",
            ([FromServices] ICreateUserUseCase useCase, [FromQuery] int pageNumber, [FromQuery] int pageSize, [FromQuery] string? name) =>
            {
                return Results.Ok(null);
            })
            .AllowAnonymous()
            .Produces<object>(StatusCodes.Status200OK);

        usergroup.MapPost(string.Empty,
            async ([FromServices] ICreateUserUseCase useCase, [FromBody] CreateUserRequest request, IValidator<CreateUserRequest> validator) =>
            {
                var validationResult = await validator.ValidateAsync(request);

                if (!validationResult.IsValid)
                    return Results.BadRequest(validationResult.Errors);

                var retorno = await useCase.ExecuteAsync(request);

                return Results.Ok(retorno);
            })
            .AllowAnonymous()
            .Produces<object>(StatusCodes.Status200OK);

        usergroup.MapPut("{id}",
            ([FromServices] ICreateUserUseCase useCase, [FromRoute] string id, [FromBody] CreateUserRequest request) =>
            {
                return Results.Ok(null);
            })
            .RequireAuthorization()
            .Produces<object>(StatusCodes.Status200OK);

        return app;
    }
}
