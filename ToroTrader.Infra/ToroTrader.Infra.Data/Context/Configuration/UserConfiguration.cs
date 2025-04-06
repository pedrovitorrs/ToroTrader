using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToroTrader.Application.Domain.Entities;

namespace ToroTrader.Infra.Data.Context.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(u => u.Id);

        builder.Property(u => u.Id)
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(u => u.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(u => u.AccountId)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.ClientId)
            .ValueGeneratedOnAdd()
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(u => u.Balance)
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(u => u.DocumentNumber)
            .IsRequired()
            .HasMaxLength(14);

        DefaultData(builder);
    }

    public static void DefaultData(EntityTypeBuilder<User> builder)
    {
        var user = new User(name: "Peter Investidor",
                balance: 5000,
                documentNumber: "01234567809",
                accountId: "00001",
                clientId: "12454");

        user.SetId(new Guid("F97E565D-08AF-4281-BC11-C0206EAE06FA"));
        user.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
        user.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

        builder.HasData(user);
    }
}
