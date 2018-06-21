using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RockPaperScissorsBoom.Server.Data.Migrations
{
    public partial class CreateGameRecordTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GameRecordId",
                table: "BotRecords",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GameRecords",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    GameDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameRecords", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BotRecords_GameRecordId",
                table: "BotRecords",
                column: "GameRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_BotRecords_GameRecords_GameRecordId",
                table: "BotRecords",
                column: "GameRecordId",
                principalTable: "GameRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BotRecords_GameRecords_GameRecordId",
                table: "BotRecords");

            migrationBuilder.DropTable(
                name: "GameRecords");

            migrationBuilder.DropIndex(
                name: "IX_BotRecords_GameRecordId",
                table: "BotRecords");

            migrationBuilder.DropColumn(
                name: "GameRecordId",
                table: "BotRecords");
        }
    }
}
