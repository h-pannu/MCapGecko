﻿// <auto-generated />
using System;
using MCapGecko.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MCapGecko.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220910200931_coin")]
    partial class coin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("MCapGecko.Shared.Models.Coin", b =>
                {
                    b.Property<string>("id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double?>("ath")
                        .HasColumnType("float");

                    b.Property<double?>("ath_change_percentage")
                        .HasColumnType("float");

                    b.Property<DateTime?>("ath_date")
                        .HasColumnType("datetime2");

                    b.Property<double?>("atl")
                        .HasColumnType("float");

                    b.Property<double?>("atl_change_percentage")
                        .HasColumnType("float");

                    b.Property<DateTime?>("atl_date")
                        .HasColumnType("datetime2");

                    b.Property<double?>("circulating_supply")
                        .HasColumnType("float");

                    b.Property<double?>("current_price")
                        .HasColumnType("float");

                    b.Property<long?>("fully_diluted_valuation")
                        .HasColumnType("bigint");

                    b.Property<double?>("high_24h")
                        .HasColumnType("float");

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("last_updated")
                        .HasColumnType("datetime2");

                    b.Property<double?>("low_24h")
                        .HasColumnType("float");

                    b.Property<long?>("market_cap")
                        .HasColumnType("bigint");

                    b.Property<double?>("market_cap_change_24h")
                        .HasColumnType("float");

                    b.Property<double?>("market_cap_change_percentage_24h")
                        .HasColumnType("float");

                    b.Property<int?>("market_cap_rank")
                        .HasColumnType("int");

                    b.Property<double?>("max_supply")
                        .HasColumnType("float");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("price_change_24h")
                        .HasColumnType("float");

                    b.Property<double?>("price_change_percentage_24h")
                        .HasColumnType("float");

                    b.Property<string>("symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("total_supply")
                        .HasColumnType("float");

                    b.Property<double?>("total_volume")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Coins");
                });
#pragma warning restore 612, 618
        }
    }
}
