using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bloodcraft.Web.Data.Migrations
{
    public partial class FixedBuldingsName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buldings_Castles_CastleId",
                table: "Buldings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buldings",
                table: "Buldings");

            migrationBuilder.RenameTable(
                name: "Buldings",
                newName: "Buildings");

            migrationBuilder.RenameIndex(
                name: "IX_Buldings_CastleId",
                table: "Buildings",
                newName: "IX_Buildings_CastleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Castles_CastleId",
                table: "Buildings",
                column: "CastleId",
                principalTable: "Castles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Castles_CastleId",
                table: "Buildings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "Buldings");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_CastleId",
                table: "Buldings",
                newName: "IX_Buldings_CastleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buldings",
                table: "Buldings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buldings_Castles_CastleId",
                table: "Buldings",
                column: "CastleId",
                principalTable: "Castles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
