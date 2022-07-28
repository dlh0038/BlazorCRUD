using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCRUD.Server.Migrations.Movie
{
    public partial class synopsis : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Synopsis",
                table: "Movies",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 1,
                column: "Synopsis",
                value: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 2,
                column: "Synopsis",
                value: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 3,
                column: "Synopsis",
                value: "");

            migrationBuilder.UpdateData(
                table: "Movies",
                keyColumn: "ID",
                keyValue: 4,
                column: "Synopsis",
                value: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Synopsis",
                table: "Movies");
        }
    }
}
