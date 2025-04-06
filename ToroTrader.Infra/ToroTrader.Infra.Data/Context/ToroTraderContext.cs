using Microsoft.EntityFrameworkCore;
using ToroTrader.Application.Domain.Entities;
using ToroTrader.Infra.Data.Context.Configuration.Base;

namespace ToroTrader.Infra.Data.Context;

public class ToroTraderContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Product> Products { get; set; }

    public ToroTraderContext(DbContextOptions<ToroTraderContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Activator.CreateInstance<UtcDateTimeConfiguration>().Configure(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BootstrapModule).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}
