using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcBook.Migrations
{
    public partial class Alter_Author_AddEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Autors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Autors");
        }
    }
}
