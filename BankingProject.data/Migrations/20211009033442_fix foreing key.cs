using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingProject.Migrations
{
    public partial class fixforeingkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Users_UserId",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Cuentas_CuentaId",
                table: "Transacciones");

            migrationBuilder.RenameColumn(
                name: "CuentaId",
                table: "Transacciones",
                newName: "CuentaIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacciones_CuentaId",
                table: "Transacciones",
                newName: "IX_Transacciones_CuentaIdId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Cuentas",
                newName: "UserIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_UserId",
                table: "Cuentas",
                newName: "IX_Cuentas_UserIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Users_UserIdId",
                table: "Cuentas",
                column: "UserIdId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Cuentas_CuentaIdId",
                table: "Transacciones",
                column: "CuentaIdId",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Users_UserIdId",
                table: "Cuentas");

            migrationBuilder.DropForeignKey(
                name: "FK_Transacciones_Cuentas_CuentaIdId",
                table: "Transacciones");

            migrationBuilder.RenameColumn(
                name: "CuentaIdId",
                table: "Transacciones",
                newName: "CuentaId");

            migrationBuilder.RenameIndex(
                name: "IX_Transacciones_CuentaIdId",
                table: "Transacciones",
                newName: "IX_Transacciones_CuentaId");

            migrationBuilder.RenameColumn(
                name: "UserIdId",
                table: "Cuentas",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Cuentas_UserIdId",
                table: "Cuentas",
                newName: "IX_Cuentas_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Users_UserId",
                table: "Cuentas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transacciones_Cuentas_CuentaId",
                table: "Transacciones",
                column: "CuentaId",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
