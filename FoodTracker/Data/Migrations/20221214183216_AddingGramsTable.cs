using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FoodTracker.Data.Migrations
{
    public partial class AddingGramsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Grams",
                table: "Food",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grams",
                table: "Food");
        }
    }
}
