using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingProject.Migrations
{
    public partial class agregar_propiedades_tabla_users : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Celular",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Direccion",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Intentos",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IntentosMaximos",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "Telefono",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Celular",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Direccion",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Intentos",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IntentosMaximos",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Telefono",
                table: "Users");
        }
    }
}
