using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCRUD.Server.Migrations.Movie
{
    public partial class addedMovies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Genre = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "Genre", "Price", "ReleaseDate", "Title" },
                values: new object[] { 1, "Romantic Comedy", 7.99m, new DateTime(1989, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "When Harry Met Sally" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "Genre", "Price", "ReleaseDate", "Title" },
                values: new object[] { 2, "Comedy", 8.99m, new DateTime(1984, 3, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghostbusters " });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "Genre", "Price", "ReleaseDate", "Title" },
                values: new object[] { 3, "Comedy", 9.99m, new DateTime(1986, 2, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ghostbusters 2" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "ID", "Genre", "Price", "ReleaseDate", "Title" },
                values: new object[] { 4, "Western", 3.99m, new DateTime(1959, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rio Bravo" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
