using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FutStats.Infrastructure.Database.Migrations
{
    public partial class UpdateTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Player_Team_TeamEntityId",
                table: "Player");

            migrationBuilder.DropIndex(
                name: "IX_Player_TeamEntityId",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "TeamEntityId",
                table: "Player");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "TeamEntityId",
                table: "Player",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Player_TeamEntityId",
                table: "Player",
                column: "TeamEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Player_Team_TeamEntityId",
                table: "Player",
                column: "TeamEntityId",
                principalTable: "Team",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
