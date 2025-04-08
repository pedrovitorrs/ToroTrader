using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToroTrader.Application.Domain.Structure.Repositories;
using ToroTrader.Infra.Data.Context;
using ToroTrader.Infra.Data.Context.Repository;

namespace ToroTrader.Infra.Data;

public static class BootstrapModule
{
    public static void RegisterInfraData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddDbContext<ToroTraderContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("Postgres"))
            .ConfigureWarnings(w => w.Ignore(RelationalEventId.PendingModelChangesWarning))
            .EnableDetailedErrors());

    }
}
