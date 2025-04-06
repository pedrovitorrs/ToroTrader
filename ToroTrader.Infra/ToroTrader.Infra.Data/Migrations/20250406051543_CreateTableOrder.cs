using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToroTrader.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BondAsset = table.Column<string>(type: "text", nullable: false),
                    Index = table.Column<string>(type: "text", nullable: false),
                    Tax = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    IssuerName = table.Column<string>(type: "text", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    AccountId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    ClientId = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Balance = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    LastAccess = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "Id", "BondAsset", "CreatedDate", "Index", "IssuerName", "Stock", "Tax", "UnitPrice", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("0a8c8ba3-f9bc-423c-bccf-8234de4b7ef7"), "LCI", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "CDI", "Toro Investimento", 18, 11.8m, 900m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("1875ac46-ca8a-4daf-970f-e6949ab6a02a"), "CRI", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "IPCA", "Toro Investimento", 12, 6.0m, 2300m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("249f360f-2909-41c2-a2f7-a28ab0f68d4a"), "CDB", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "IPCA", "Toro Investimento", 19, 7.8m, 1700m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("521dc1ec-7f41-48b7-8679-ca3b1afc71b7"), "CDB", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "CDI", "Toro Investimento", 50, 12.5m, 1100m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("6a9e7f2c-cde6-4b64-80c4-7f928f73d4b4"), "CRI", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "CDI", "Toro Investimento", 15, 13.2m, 2500m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("6e113c14-3f44-4f42-bbd3-4ba0cebcb859"), "CDB", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "CDI", "Toro Investimento", 38, 11.0m, 1000m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("71b5d8ad-1e24-49c7-af9f-6d45d5edcf7d"), "LCI", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "IPCA", "Toro Investimento", 25, 6.5m, 1800m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("8a8451d7-1057-4912-9f94-b3afd943fb8b"), "CDB", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Pre", "Toro Investimento", 28, 13.0m, 1600m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("8c8e41a2-f6ce-4457-9b8c-15c4ed23910b"), "CDB", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "SELIC", "Toro Investimento", 40, 11.2m, 1200m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("90a59d76-46f8-46b5-a9e3-0a54a84c4387"), "CRA", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Pre", "Toro Investimento", 35, 9.8m, 1300m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("a2378e7e-33d4-4f70-89a0-8b6d4b4507ce"), "CRA", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "CDI", "Toro Investimento", 20, 10.9m, 1250m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ad5b79d2-bca0-4d4b-8501-53a3c927d27d"), "CDB", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "IPCA", "Toro Investimento", 60, 7.3m, 1000m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("b1f0e320-8f31-4e68-b450-173e4c1b4d7e"), "LCA", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "CDI", "Toro Investimento", 30, 10.5m, 1500m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("d1a0a3a7-c6ba-4f0a-9cb0-0ef20797c641"), "CDB", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "IPCA", "Toro Investimento", 100, 5.0m, 1000m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("ddc3c57f-1b7d-49a0-af24-917ffac9df9d"), "LCA", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "SELIC", "Toro Investimento", 24, 9.4m, 1450m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("e2a7b8d2-2fa8-4214-9de3-ce2e593d2b3c"), "LCI", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Pre", "Toro Investimento", 20, 12.0m, 2000m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f99c7498-998b-407b-91ce-9289f1de18b2"), "LCA", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "SELIC", "Toro Investimento", 22, 10.0m, 1400m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AccountId", "Balance", "ClientId", "CreatedDate", "DocumentNumber", "LastAccess", "Name", "UpdatedDate" },
                values: new object[] { new Guid("f97e565d-08af-4281-bc11-c0206eae06fa"), "00001", 100000m, "12454", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "01234567809", new DateTime(1, 1, 1, 2, 0, 0, 0, DateTimeKind.Utc), "Peter Investidor", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.InsertData(
                table: "order",
                columns: new[] { "Id", "CreatedDate", "ErrorMessage", "ProductId", "Quantity", "Status", "UpdatedDate", "UserId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000001"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("d1a0a3a7-c6ba-4f0a-9cb0-0ef20797c641"), 1, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000002"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("e2a7b8d2-2fa8-4214-9de3-ce2e593d2b3c"), 2, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("b1f0e320-8f31-4e68-b450-173e4c1b4d7e"), 3, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("8c8e41a2-f6ce-4457-9b8c-15c4ed23910b"), 4, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("71b5d8ad-1e24-49c7-af9f-6d45d5edcf7d"), 5, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000006"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("6a9e7f2c-cde6-4b64-80c4-7f928f73d4b4"), 1, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000007"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("90a59d76-46f8-46b5-a9e3-0a54a84c4387"), 2, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000008"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("521dc1ec-7f41-48b7-8679-ca3b1afc71b7"), 3, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000009"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("f99c7498-998b-407b-91ce-9289f1de18b2"), 4, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000010"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("ad5b79d2-bca0-4d4b-8501-53a3c927d27d"), 5, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000011"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("0a8c8ba3-f9bc-423c-bccf-8234de4b7ef7"), 1, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000012"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("8a8451d7-1057-4912-9f94-b3afd943fb8b"), 2, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000013"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("1875ac46-ca8a-4daf-970f-e6949ab6a02a"), 3, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000014"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("a2378e7e-33d4-4f70-89a0-8b6d4b4507ce"), 4, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000015"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("6e113c14-3f44-4f42-bbd3-4ba0cebcb859"), 5, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000016"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("ddc3c57f-1b7d-49a0-af24-917ffac9df9d"), 1, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") },
                    { new Guid("00000000-0000-0000-0000-000000000017"), new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), null, new Guid("249f360f-2909-41c2-a2f7-a28ab0f68d4a"), 2, "Pendente", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("f97e565d-08af-4281-bc11-c0206eae06fa") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_ProductId",
                table: "order",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_order_UserId",
                table: "order",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
