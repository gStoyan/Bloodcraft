using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bloodcraft.Web.Data.Migrations
{
    public partial class DeleteFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Castles_AspNetUsers_UserId",
                table: "Castles");

            migrationBuilder.AddForeignKey(
                name: "FK_Castles_AspNetUsers_UserId",
                table: "Castles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Castles_AspNetUsers_UserId",
                table: "Castles");

            migrationBuilder.AddForeignKey(
                name: "FK_Castles_AspNetUsers_UserId",
                table: "Castles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
