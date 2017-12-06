using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bloodcraft.Web.Data.Migrations
{
    public partial class TotalBloodAndGold : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Blood",
                table: "Castles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Gold",
                table: "Castles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Castles",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalBloodIncome",
                table: "Castles",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalGoldIncome",
                table: "Castles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Blood",
                table: "Castles");

            migrationBuilder.DropColumn(
                name: "Gold",
                table: "Castles");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Castles");

            migrationBuilder.DropColumn(
                name: "TotalBloodIncome",
                table: "Castles");

            migrationBuilder.DropColumn(
                name: "TotalGoldIncome",
                table: "Castles");
        }
    }
}
