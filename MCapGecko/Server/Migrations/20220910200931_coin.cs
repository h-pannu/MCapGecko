using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MCapGecko.Server.Migrations
{
    public partial class coin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    current_price = table.Column<double>(type: "float", nullable: true),
                    market_cap = table.Column<long>(type: "bigint", nullable: true),
                    market_cap_rank = table.Column<int>(type: "int", nullable: true),
                    fully_diluted_valuation = table.Column<long>(type: "bigint", nullable: true),
                    total_volume = table.Column<double>(type: "float", nullable: true),
                    high_24h = table.Column<double>(type: "float", nullable: true),
                    low_24h = table.Column<double>(type: "float", nullable: true),
                    price_change_24h = table.Column<double>(type: "float", nullable: true),
                    price_change_percentage_24h = table.Column<double>(type: "float", nullable: true),
                    market_cap_change_24h = table.Column<double>(type: "float", nullable: true),
                    market_cap_change_percentage_24h = table.Column<double>(type: "float", nullable: true),
                    circulating_supply = table.Column<double>(type: "float", nullable: true),
                    total_supply = table.Column<double>(type: "float", nullable: true),
                    max_supply = table.Column<double>(type: "float", nullable: true),
                    ath = table.Column<double>(type: "float", nullable: true),
                    ath_change_percentage = table.Column<double>(type: "float", nullable: true),
                    ath_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    atl = table.Column<double>(type: "float", nullable: true),
                    atl_change_percentage = table.Column<double>(type: "float", nullable: true),
                    atl_date = table.Column<DateTime>(type: "datetime2", nullable: true),
                    last_updated = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coins");
        }
    }
}
