using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTracker.Data.Migrations
{
    public partial class test1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Food_Diary_DiaryId",
                table: "Food");

            migrationBuilder.DropTable(
                name: "Diary");

            migrationBuilder.DropIndex(
                name: "IX_Food_DiaryId",
                table: "Food");

            migrationBuilder.DropColumn(
                name: "DiaryId",
                table: "Food");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Food",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Food",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "DiaryId",
                table: "Food",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Diary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalorieTarget = table.Column<double>(type: "float", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalCalories = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diary", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Food_DiaryId",
                table: "Food",
                column: "DiaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Food_Diary_DiaryId",
                table: "Food",
                column: "DiaryId",
                principalTable: "Diary",
                principalColumn: "Id");
        }
    }
}
