using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FutStats.Infrastructure.Database.Migrations
{
    public partial class EntitiesExtend : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistic_Player_PlayerId",
                table: "Statistic");

            migrationBuilder.DropIndex(
                name: "IX_Statistic_PlayerId",
                table: "Statistic");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Team",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlayerId",
                table: "Statistic",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_PlayerId",
                table: "Statistic",
                column: "PlayerId",
                unique: true,
                filter: "[PlayerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Statistic_Player_PlayerId",
                table: "Statistic",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statistic_Player_PlayerId",
                table: "Statistic");

            migrationBuilder.DropIndex(
                name: "IX_Statistic_PlayerId",
                table: "Statistic");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Team");

            migrationBuilder.AlterColumn<Guid>(
                name: "PlayerId",
                table: "Statistic",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statistic_PlayerId",
                table: "Statistic",
                column: "PlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Statistic_Player_PlayerId",
                table: "Statistic",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
