using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCRUD.Server.Migrations.Database
{
    public partial class updatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "userdetails",
                newName: "StreetAddress");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "userdetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "userdetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "userdetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "userdetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "userdetails");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "userdetails");

            migrationBuilder.DropColumn(
                name: "State",
                table: "userdetails");

            migrationBuilder.DropColumn(
                name: "Zip",
                table: "userdetails");

            migrationBuilder.RenameColumn(
                name: "StreetAddress",
                table: "userdetails",
                newName: "Address");
        }
    }
}
