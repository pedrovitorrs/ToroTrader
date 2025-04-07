using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ToroTrader.Application;
using ToroTrader.Application.Domain.Structure.JWT;
using ToroTrader.Infra.Data;
using ToroTrader.Infra.IoC.JWT;
using ToroTrader.Infra.IoC.OpenAPI;
using EasyNetQ;
using ToroTrader.Application.Events.Interfaces;
using ToroTrader.Application.Events;
using ToroTrader.Infra.Messaging;
using ToroTrader.Application.Domain.Events;

namespace ToroTrader.Infra.IoC;

public static class BootstrapModule
{

    public static void AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer<BearerSecuritySchemeTransformer>();
        });

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"])),
                ClockSkew = TimeSpan.Zero,
            };
        });

        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
        });

        services.AddScoped<ITokenService, TokenService>();

        services.AddScoped<IPasswordHash, PasswordHash>();
        services.AddHttpContextAccessor();
        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.RegisterUseCases();

        services.RegisterInfraData(configuration);

        services.AddScoped<IEventPublisher<PublisherEvent>, CreateOrderEventPublisher<PublisherEvent>>();

        services.AddTransient<IEventConsumer<PublisherEvent, Guid>, CreateOrderEventConsumer>();
        services.AddScoped<IConsumerSubscriptions, ConsumerSubscriptions>();
        //services.AddScoped<IConsumerSubscriptions, ConsumerSubscriptions>();
        services.AddSingleton(RabbitHutch.CreateBus("host=localhost;username=rabbitmq;password=rabbitmq;virtualHost=/"));
    }
}
