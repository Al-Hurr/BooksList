using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcBook.Migrations
{
    public partial class Alter_Author : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Autors");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Autors",
                type: "text",
                nullable: true);
        }
    }
}
