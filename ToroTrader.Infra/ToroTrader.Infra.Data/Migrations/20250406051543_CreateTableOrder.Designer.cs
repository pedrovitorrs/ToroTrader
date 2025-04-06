﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ToroTrader.Infra.Data.Context;

#nullable disable

namespace ToroTrader.Infra.Data.Migrations
{
    [DbContext(typeof(ToroTraderContext))]
    [Migration("20250406051543_CreateTableOrder")]
    partial class CreateTableOrder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ToroTrader.Application.Domain.Entities.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ErrorMessage")
                        .HasColumnType("text");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("order", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000001"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("d1a0a3a7-c6ba-4f0a-9cb0-0ef20797c641"),
                            Quantity = 1,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000002"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("e2a7b8d2-2fa8-4214-9de3-ce2e593d2b3c"),
                            Quantity = 2,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000003"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("b1f0e320-8f31-4e68-b450-173e4c1b4d7e"),
                            Quantity = 3,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000004"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("8c8e41a2-f6ce-4457-9b8c-15c4ed23910b"),
                            Quantity = 4,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000005"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("71b5d8ad-1e24-49c7-af9f-6d45d5edcf7d"),
                            Quantity = 5,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000006"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("6a9e7f2c-cde6-4b64-80c4-7f928f73d4b4"),
                            Quantity = 1,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000007"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("90a59d76-46f8-46b5-a9e3-0a54a84c4387"),
                            Quantity = 2,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000008"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("521dc1ec-7f41-48b7-8679-ca3b1afc71b7"),
                            Quantity = 3,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000009"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("f99c7498-998b-407b-91ce-9289f1de18b2"),
                            Quantity = 4,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000010"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("ad5b79d2-bca0-4d4b-8501-53a3c927d27d"),
                            Quantity = 5,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000011"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("0a8c8ba3-f9bc-423c-bccf-8234de4b7ef7"),
                            Quantity = 1,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000012"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("8a8451d7-1057-4912-9f94-b3afd943fb8b"),
                            Quantity = 2,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000013"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("1875ac46-ca8a-4daf-970f-e6949ab6a02a"),
                            Quantity = 3,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000014"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("a2378e7e-33d4-4f70-89a0-8b6d4b4507ce"),
                            Quantity = 4,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000015"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("6e113c14-3f44-4f42-bbd3-4ba0cebcb859"),
                            Quantity = 5,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000016"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("ddc3c57f-1b7d-49a0-af24-917ffac9df9d"),
                            Quantity = 1,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        },
                        new
                        {
                            Id = new Guid("00000000-0000-0000-0000-000000000017"),
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            ProductId = new Guid("249f360f-2909-41c2-a2f7-a28ab0f68d4a"),
                            Quantity = 2,
                            Status = "Pendente",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            UserId = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa")
                        });
                });

            modelBuilder.Entity("ToroTrader.Application.Domain.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BondAsset")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Index")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("IssuerName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Stock")
                        .HasColumnType("integer");

                    b.Property<decimal>("Tax")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("product", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("d1a0a3a7-c6ba-4f0a-9cb0-0ef20797c641"),
                            BondAsset = "CDB",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "IPCA",
                            IssuerName = "Toro Investimento",
                            Stock = 100,
                            Tax = 5.0m,
                            UnitPrice = 1000m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("e2a7b8d2-2fa8-4214-9de3-ce2e593d2b3c"),
                            BondAsset = "LCI",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "Pre",
                            IssuerName = "Toro Investimento",
                            Stock = 20,
                            Tax = 12.0m,
                            UnitPrice = 2000m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("b1f0e320-8f31-4e68-b450-173e4c1b4d7e"),
                            BondAsset = "LCA",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "CDI",
                            IssuerName = "Toro Investimento",
                            Stock = 30,
                            Tax = 10.5m,
                            UnitPrice = 1500m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("8c8e41a2-f6ce-4457-9b8c-15c4ed23910b"),
                            BondAsset = "CDB",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "SELIC",
                            IssuerName = "Toro Investimento",
                            Stock = 40,
                            Tax = 11.2m,
                            UnitPrice = 1200m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("71b5d8ad-1e24-49c7-af9f-6d45d5edcf7d"),
                            BondAsset = "LCI",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "IPCA",
                            IssuerName = "Toro Investimento",
                            Stock = 25,
                            Tax = 6.5m,
                            UnitPrice = 1800m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("6a9e7f2c-cde6-4b64-80c4-7f928f73d4b4"),
                            BondAsset = "CRI",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "CDI",
                            IssuerName = "Toro Investimento",
                            Stock = 15,
                            Tax = 13.2m,
                            UnitPrice = 2500m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("90a59d76-46f8-46b5-a9e3-0a54a84c4387"),
                            BondAsset = "CRA",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "Pre",
                            IssuerName = "Toro Investimento",
                            Stock = 35,
                            Tax = 9.8m,
                            UnitPrice = 1300m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("521dc1ec-7f41-48b7-8679-ca3b1afc71b7"),
                            BondAsset = "CDB",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "CDI",
                            IssuerName = "Toro Investimento",
                            Stock = 50,
                            Tax = 12.5m,
                            UnitPrice = 1100m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("f99c7498-998b-407b-91ce-9289f1de18b2"),
                            BondAsset = "LCA",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "SELIC",
                            IssuerName = "Toro Investimento",
                            Stock = 22,
                            Tax = 10.0m,
                            UnitPrice = 1400m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("ad5b79d2-bca0-4d4b-8501-53a3c927d27d"),
                            BondAsset = "CDB",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "IPCA",
                            IssuerName = "Toro Investimento",
                            Stock = 60,
                            Tax = 7.3m,
                            UnitPrice = 1000m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("0a8c8ba3-f9bc-423c-bccf-8234de4b7ef7"),
                            BondAsset = "LCI",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "CDI",
                            IssuerName = "Toro Investimento",
                            Stock = 18,
                            Tax = 11.8m,
                            UnitPrice = 900m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("8a8451d7-1057-4912-9f94-b3afd943fb8b"),
                            BondAsset = "CDB",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "Pre",
                            IssuerName = "Toro Investimento",
                            Stock = 28,
                            Tax = 13.0m,
                            UnitPrice = 1600m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("1875ac46-ca8a-4daf-970f-e6949ab6a02a"),
                            BondAsset = "CRI",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "IPCA",
                            IssuerName = "Toro Investimento",
                            Stock = 12,
                            Tax = 6.0m,
                            UnitPrice = 2300m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("a2378e7e-33d4-4f70-89a0-8b6d4b4507ce"),
                            BondAsset = "CRA",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "CDI",
                            IssuerName = "Toro Investimento",
                            Stock = 20,
                            Tax = 10.9m,
                            UnitPrice = 1250m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("6e113c14-3f44-4f42-bbd3-4ba0cebcb859"),
                            BondAsset = "CDB",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "CDI",
                            IssuerName = "Toro Investimento",
                            Stock = 38,
                            Tax = 11.0m,
                            UnitPrice = 1000m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("ddc3c57f-1b7d-49a0-af24-917ffac9df9d"),
                            BondAsset = "LCA",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "SELIC",
                            IssuerName = "Toro Investimento",
                            Stock = 24,
                            Tax = 9.4m,
                            UnitPrice = 1450m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        },
                        new
                        {
                            Id = new Guid("249f360f-2909-41c2-a2f7-a28ab0f68d4a"),
                            BondAsset = "CDB",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            Index = "IPCA",
                            IssuerName = "Toro Investimento",
                            Stock = 19,
                            Tax = 7.8m,
                            UnitPrice = 1700m,
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("ToroTrader.Application.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<decimal>("Balance")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("character varying(14)");

                    b.Property<DateTime>("LastAccess")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f97e565d-08af-4281-bc11-c0206eae06fa"),
                            AccountId = "00001",
                            Balance = 100000m,
                            ClientId = "12454",
                            CreatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc),
                            DocumentNumber = "01234567809",
                            LastAccess = new DateTime(1, 1, 1, 2, 0, 0, 0, DateTimeKind.Utc),
                            Name = "Peter Investidor",
                            UpdatedDate = new DateTime(2025, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc)
                        });
                });

            modelBuilder.Entity("ToroTrader.Application.Domain.Entities.Order", b =>
                {
                    b.HasOne("ToroTrader.Application.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ToroTrader.Application.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
