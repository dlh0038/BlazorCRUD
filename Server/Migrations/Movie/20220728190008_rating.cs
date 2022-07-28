using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCRUD.Server.Migrations.Movie
{
    public partial class rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rating",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 1,
                column: "Rating",
                value: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 2,
                column: "Rating",
                value: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 3,
                column: "Rating",
                value: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 4,
                column: "Rating",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");
        }
    }
}
