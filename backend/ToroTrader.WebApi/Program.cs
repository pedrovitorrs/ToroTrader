using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
using System.Text;
using ToroTrader.Infra.IoC;
using ToroTrader.Infra.IoC.Extension;
using ToroTrader.WebApi.Endpoints;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthorization();

builder.Services.AddInfraStructure(builder.Configuration);

var app = builder.Build();

app.UseCors("AllowAllOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.MapScalarApiReference(options =>
    {
        options.WithTheme(ScalarTheme.DeepSpace)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
}

//app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapGroup("api/v1/")
    .WithOpenApi()
    .AddUserEndpoints("/users", "Users")
    .AddAuthEndpoints("/auth", "Auth")
    .AddProductEndpoints("/products", "Products")
    .AddOrderEndpoints("/orders", "Orders");

app.UseRabbitListener();

app.Run();
