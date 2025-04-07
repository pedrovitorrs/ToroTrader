using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using ToroTrader.Application.Features.Auth.Login;
using ToroTrader.Application.Features.Orders.CreateOrder;
using ToroTrader.Application.Features.Orders.GetOrdersByUser;
using ToroTrader.Application.Features.Products.GetProducts;
using ToroTrader.Application.Features.Products.GetProductsTopTraded;
using ToroTrader.Application.Features.Users.CreateUser;
using ToroTrader.Infra.IoC.FluentValidation.User;

namespace ToroTrader.Application;

public static class BoostrapModule
{
    public static void RegisterUseCases(this IServiceCollection services)
    {
        //services.AddScoped<IRepository<TEntity>, Repository<TEntity>>();

        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        services.AddScoped<ILoginUseCase, LoginUseCase>();
        services.AddScoped<IGetProductsHandler, GetProductsHandler>();
        services.AddScoped<IGetProductsTopTradedHandler, GetProductsTopTradedHandler>();
        services.AddScoped<ICreateOrderUseCase, CreateOrderUseCase>();
        services.AddScoped<IGetOrdersByUserHandler, GetOrdersByUserHandler>();

        services.AddFluentValidationAutoValidation(); // Para validação automática no binding do body
        services.AddValidatorsFromAssemblyContaining<CreateUserRequestValidator>();
    }
}
