using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bloodcraft.Web.Data.Migrations
{
    public partial class BuldingsAndMinions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Castles",
                columns: table => new
                {
                    CastleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Castles", x => x.CastleId);
                    table.ForeignKey(
                        name: "FK_Castles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Buldings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BloodCost = table.Column<int>(nullable: false),
                    BloodIncome = table.Column<int>(nullable: false),
                    BuildTime = table.Column<int>(nullable: false),
                    CastleId = table.Column<int>(nullable: false),
                    GoldCost = table.Column<int>(nullable: false),
                    GoldIncome = table.Column<int>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buldings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buldings_Castles_CastleId",
                        column: x => x.CastleId,
                        principalTable: "Castles",
                        principalColumn: "CastleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Minions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttackPoints = table.Column<int>(nullable: false),
                    BloodCost = table.Column<int>(nullable: false),
                    BloodPoints = table.Column<int>(nullable: false),
                    CastleId = table.Column<int>(nullable: false),
                    DefencePoints = table.Column<int>(nullable: false),
                    GoldCost = table.Column<int>(nullable: false),
                    ImgUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Minions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Minions_Castles_CastleId",
                        column: x => x.CastleId,
                        principalTable: "Castles",
                        principalColumn: "CastleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Buldings_CastleId",
                table: "Buldings",
                column: "CastleId");

            migrationBuilder.CreateIndex(
                name: "IX_Castles_UserId",
                table: "Castles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Minions_CastleId",
                table: "Minions",
                column: "CastleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buldings");

            migrationBuilder.DropTable(
                name: "Minions");

            migrationBuilder.DropTable(
                name: "Castles");
        }
    }
}
