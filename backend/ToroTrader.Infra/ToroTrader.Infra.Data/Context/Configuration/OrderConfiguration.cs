using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToroTrader.Application.Domain.Entities;

namespace ToroTrader.Infra.Data.Context.Configuration
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("order");

            builder.HasKey(up => up.Id);

            builder.Property(up => up.Id)
                .ValueGeneratedOnAdd();

            builder.Property(up => up.UserId)
                .IsRequired();

            builder.Property(up => up.ProductId)
                .IsRequired();

            builder.Property(up => up.Quantity)
                .IsRequired();

            builder.Property(x => x.Status)
               .HasConversion<string>()
               .IsRequired();

            builder.Property(x => x.Status)
                .HasMaxLength(200);

            builder.HasOne(up => up.User)
                .WithMany()
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(up => up.Product)
                .WithMany()
                .HasForeignKey(up => up.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            DefaultData(builder);
        }

        public static void DefaultData(EntityTypeBuilder<Order> builder)
        {
            var userId = Guid.Parse("F97E565D-08AF-4281-BC11-C0206EAE06FA");

            var validProductIds = new List<Guid>
            {
                Guid.Parse("D1A0A3A7-C6BA-4F0A-9CB0-0EF20797C641"), // CDB
                Guid.Parse("E2A7B8D2-2FA8-4214-9DE3-CE2E593D2B3C"), // LCI
                Guid.Parse("B1F0E320-8F31-4E68-B450-173E4C1B4D7E"), // LCA
                Guid.Parse("8C8E41A2-F6CE-4457-9B8C-15C4ED23910B"), // CDB
                Guid.Parse("71B5D8AD-1E24-49C7-AF9F-6D45D5EDCF7D"), // LCI
                Guid.Parse("6A9E7F2C-CDE6-4B64-80C4-7F928F73D4B4"), // CRI
                Guid.Parse("90A59D76-46F8-46B5-A9E3-0A54A84C4387"), // CRA
                Guid.Parse("521DC1EC-7F41-48B7-8679-CA3B1AFC71B7"), // CDB
                Guid.Parse("F99C7498-998B-407B-91CE-9289F1DE18B2"), // LCA
                Guid.Parse("AD5B79D2-BCA0-4D4B-8501-53A3C927D27D"), // CDB
                Guid.Parse("0A8C8BA3-F9BC-423C-BCCF-8234DE4B7EF7"), // LCI
                Guid.Parse("8A8451D7-1057-4912-9F94-B3AFD943FB8B"), // CDB
                Guid.Parse("1875AC46-CA8A-4DAF-970F-E6949AB6A02A"), // CRI
                Guid.Parse("A2378E7E-33D4-4F70-89A0-8B6D4B4507CE"), // CRA
                Guid.Parse("6E113C14-3F44-4F42-BBD3-4BA0CEBCB859"), // CDB
                Guid.Parse("DDC3C57F-1B7D-49A0-AF24-917FFAC9DF9D"), // LCA
                Guid.Parse("249F360F-2909-41C2-A2F7-A28AB0F68D4A"), // CDB
            };

            var orders = validProductIds.Select((productId, index) =>
            {
                var order = new Order(userId, productId, quantity: 1 + (index % 5));
                order.SetId(Guid.Parse($"00000000-0000-0000-0000-0000000000{index + 1:D2}"));
                order.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
                order.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
                return order;
            }).ToList();

            builder.HasData(orders);
        }
    }
}
