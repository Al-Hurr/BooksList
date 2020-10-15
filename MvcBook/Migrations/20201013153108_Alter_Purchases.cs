using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcBook.Migrations
{
    public partial class Alter_Purchases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Purchases");

            migrationBuilder.AddColumn<int>(
                name: "Ammount",
                table: "Purchases",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ammount",
                table: "Purchases");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Purchases",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Purchases",
                type: "text",
                nullable: true);
        }
    }
}
