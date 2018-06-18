using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RockPaperScissorsBoom.Server.Data.Migrations
{
    public partial class CreateBotRecordTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BotRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompetitorId = table.Column<Guid>(nullable: true),
                    Wins = table.Column<int>(nullable: false),
                    Losses = table.Column<int>(nullable: false),
                    Ties = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BotRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BotRecords_Competitors_CompetitorId",
                        column: x => x.CompetitorId,
                        principalTable: "Competitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BotRecords_CompetitorId",
                table: "BotRecords",
                column: "CompetitorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BotRecords");
        }
    }
}
