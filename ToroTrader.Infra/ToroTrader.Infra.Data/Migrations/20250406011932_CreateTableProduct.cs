using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToroTrader.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableProduct : Migration
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

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "Id", "BondAsset", "CreatedDate", "Index", "IssuerName", "Stock", "Tax", "UnitPrice", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("d1a0a3a7-c6ba-4f0a-9cb0-0ef20797c641"), "CDB", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "IPCA", "Banco Teste", 100, 5.0m, 1000m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("e2a7b8d2-2fa8-4214-9de3-ce2e593d2b3c"), "LCI", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Pre", "Banco Teste 2", 20, 12.0m, 2000m, new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "AccountId", "Balance", "ClientId", "CreatedDate", "DocumentNumber", "LastAccess", "Name", "UpdatedDate" },
                values: new object[] { new Guid("f97e565d-08af-4281-bc11-c0206eae06fa"), "00001", 5000m, "12454", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "01234567809", new DateTime(1, 1, 1, 2, 0, 0, 0, DateTimeKind.Utc), "Peter Investidor", new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
