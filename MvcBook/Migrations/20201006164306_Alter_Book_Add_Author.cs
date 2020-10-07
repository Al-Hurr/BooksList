using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcBook.Migrations
{
    public partial class Alter_Book_Add_Author : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Book",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Book_AutorId",
                table: "Book",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Book_Autors_AutorId",
                table: "Book",
                column: "AutorId",
                principalTable: "Autors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Book_Autors_AutorId",
                table: "Book");

            migrationBuilder.DropIndex(
                name: "IX_Book_AutorId",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Book");
        }
    }
}
