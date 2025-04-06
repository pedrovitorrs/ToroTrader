using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToroTrader.Application.Domain.Entities;

namespace ToroTrader.Infra.Data.Context.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("product");
            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(u => u.BondAsset).IsRequired();
            builder.Property(u => u.Index).IsRequired();
            builder.Property(u => u.IssuerName).IsRequired();
            builder.Property(u => u.Stock).IsRequired();
            builder.Property(u => u.UnitPrice).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(u => u.Tax).HasColumnType("decimal(18,2)").IsRequired();

            DefaultData(builder);
        }

        public static void DefaultData(EntityTypeBuilder<Product> builder)
        {
            var product1 = new Product(
                bondAsset: "CDB",
                index: "IPCA",
                tax: 5.0m,
                issuerName: "Banco Teste",
                unitPrice: 1000m,
                stock: 100
            );
            product1.SetId(new Guid("D1A0A3A7-C6BA-4F0A-9CB0-0EF20797C641"));
            product1.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product1.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product2 = new Product(
                bondAsset: "LCI",
                index: "Pre",
                tax: 12.0m,
                issuerName: "Banco Teste 2",
                unitPrice: 2000m,
                stock: 20
            );
            product2.SetId(new Guid("E2A7B8D2-2FA8-4214-9DE3-CE2E593D2B3C"));
            product2.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product2.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            builder.HasData(product1, product2);
        }
    }
}
