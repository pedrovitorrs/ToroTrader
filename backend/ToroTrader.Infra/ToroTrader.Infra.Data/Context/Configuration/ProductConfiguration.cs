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
                issuerName: "Toro Investimento",
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
                issuerName: "Toro Investimento",
                unitPrice: 2000m,
                stock: 20
            );
            product2.SetId(new Guid("E2A7B8D2-2FA8-4214-9DE3-CE2E593D2B3C"));
            product2.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product2.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product3 = new Product("LCA", "CDI", 10.5m, "Toro Investimento", 1500m, 30);
            product3.SetId(Guid.Parse("B1F0E320-8F31-4E68-B450-173E4C1B4D7E"));
            product3.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product3.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product4 = new Product("CDB", "SELIC", 11.2m, "Toro Investimento", 1200m, 40);
            product4.SetId(Guid.Parse("8C8E41A2-F6CE-4457-9B8C-15C4ED23910B"));
            product4.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product4.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product5 = new Product("LCI", "IPCA", 6.5m, "Toro Investimento", 1800m, 25);
            product5.SetId(Guid.Parse("71B5D8AD-1E24-49C7-AF9F-6D45D5EDCF7D"));
            product5.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product5.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product6 = new Product("CRI", "CDI", 13.2m, "Toro Investimento", 2500m, 15);
            product6.SetId(Guid.Parse("6A9E7F2C-CDE6-4B64-80C4-7F928F73D4B4"));
            product6.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product6.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product7 = new Product("CRA", "Pre", 9.8m, "Toro Investimento", 1300m, 35);
            product7.SetId(Guid.Parse("90A59D76-46F8-46B5-A9E3-0A54A84C4387"));
            product7.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product7.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product8 = new Product("CDB", "CDI", 12.5m, "Toro Investimento", 1100m, 50);
            product8.SetId(Guid.Parse("521DC1EC-7F41-48B7-8679-CA3B1AFC71B7"));
            product8.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product8.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product9 = new Product("LCA", "SELIC", 10.0m, "Toro Investimento", 1400m, 22);
            product9.SetId(Guid.Parse("F99C7498-998B-407B-91CE-9289F1DE18B2"));
            product9.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product9.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product10 = new Product("CDB", "IPCA", 7.3m, "Toro Investimento", 1000m, 60);
            product10.SetId(Guid.Parse("AD5B79D2-BCA0-4D4B-8501-53A3C927D27D"));
            product10.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product10.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product11 = new Product("LCI", "CDI", 11.8m, "Toro Investimento", 900m, 18);
            product11.SetId(Guid.Parse("0A8C8BA3-F9BC-423C-BCCF-8234DE4B7EF7"));
            product11.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product11.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product12 = new Product("CDB", "Pre", 13.0m, "Toro Investimento", 1600m, 28);
            product12.SetId(Guid.Parse("8A8451D7-1057-4912-9F94-B3AFD943FB8B"));
            product12.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product12.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product13 = new Product("CRI", "IPCA", 6.0m, "Toro Investimento", 2300m, 12);
            product13.SetId(Guid.Parse("1875AC46-CA8A-4DAF-970F-E6949AB6A02A"));
            product13.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product13.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product14 = new Product("CRA", "CDI", 10.9m, "Toro Investimento", 1250m, 20);
            product14.SetId(Guid.Parse("A2378E7E-33D4-4F70-89A0-8B6D4B4507CE"));
            product14.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product14.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product15 = new Product("CDB", "CDI", 11.0m, "Toro Investimento", 1000m, 38);
            product15.SetId(Guid.Parse("6E113C14-3F44-4F42-BBD3-4BA0CEBCB859"));
            product15.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product15.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product16 = new Product("LCA", "SELIC", 9.4m, "Toro Investimento", 1450m, 24);
            product16.SetId(Guid.Parse("DDC3C57F-1B7D-49A0-AF24-917FFAC9DF9D"));
            product16.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product16.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            var product17 = new Product("CDB", "IPCA", 7.8m, "Toro Investimento", 1700m, 19);
            product17.SetId(Guid.Parse("249F360F-2909-41C2-A2F7-A28AB0F68D4A"));
            product17.SetCreatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));
            product17.SetUpdatedDate(DateTime.SpecifyKind(new DateTime(2025, 4, 5), DateTimeKind.Utc));

            builder.HasData(product1, product2, product3, product4, product5, product6, product7, product8,
                product9, product10, product11, product12, product13, product14, product15, product16, product17);
        }
    }
}
