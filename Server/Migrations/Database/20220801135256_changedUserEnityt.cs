using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorCRUD.Server.Migrations.Database
{
    public partial class changedUserEnityt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "userdetails",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "userdetails",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "userdetails");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "userdetails",
                newName: "Name");
        }
    }
}
