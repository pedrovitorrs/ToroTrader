using Microsoft.AspNetCore.Mvc;
using ToroTrader.Application.Features.Products.GetProducts;

namespace ToroTrader.WebApi.Endpoints
{
    public static class ProductEndpoints
    {
        public static IEndpointRouteBuilder AddProductEndpoints(this IEndpointRouteBuilder app, string route, string tag)
        {
            var productroup = app.MapGroup(route).WithTags(tag);

            productroup.MapGet("{pageNumber}/{pageSize}",
                async ([FromServices] IGetProductsHandler handler, [AsParameters] GetProductsQuery getProductsQuery) =>
                {
                    return Results.Ok(await handler.HandleAsync(getProductsQuery));
                })
                .RequireAuthorization()
                .Produces<object>(StatusCodes.Status200OK);

            return app;
        }
    }
}
