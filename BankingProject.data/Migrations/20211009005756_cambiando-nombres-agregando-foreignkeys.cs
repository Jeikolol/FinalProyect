using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingProject.Migrations
{
    public partial class cambiandonombresagregandoforeignkeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Transferencias_TransferenciaId",
                table: "Cuentas");

            migrationBuilder.DropIndex(
                name: "IX_Cuentas_TransferenciaId",
                table: "Cuentas");

            migrationBuilder.DropColumn(
                name: "cuentaDestino",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "cuentaOrigen",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "TransferenciaId",
                table: "Cuentas");

            migrationBuilder.RenameColumn(
                name: "concepto",
                table: "Transferencias",
                newName: "Concepto");

            migrationBuilder.RenameColumn(
                name: "montoAPagar",
                table: "Transferencias",
                newName: "Monto");

            migrationBuilder.AddColumn<long>(
                name: "CuentaDestinoId",
                table: "Transferencias",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CuentaOrigenId",
                table: "Transferencias",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_CuentaDestinoId",
                table: "Transferencias",
                column: "CuentaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Transferencias_CuentaOrigenId",
                table: "Transferencias",
                column: "CuentaOrigenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Cuentas_CuentaDestinoId",
                table: "Transferencias",
                column: "CuentaDestinoId",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transferencias_Cuentas_CuentaOrigenId",
                table: "Transferencias",
                column: "CuentaOrigenId",
                principalTable: "Cuentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Cuentas_CuentaDestinoId",
                table: "Transferencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Transferencias_Cuentas_CuentaOrigenId",
                table: "Transferencias");

            migrationBuilder.DropIndex(
                name: "IX_Transferencias_CuentaDestinoId",
                table: "Transferencias");

            migrationBuilder.DropIndex(
                name: "IX_Transferencias_CuentaOrigenId",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "CuentaDestinoId",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "CuentaOrigenId",
                table: "Transferencias");

            migrationBuilder.RenameColumn(
                name: "Concepto",
                table: "Transferencias",
                newName: "concepto");

            migrationBuilder.RenameColumn(
                name: "Monto",
                table: "Transferencias",
                newName: "montoAPagar");

            migrationBuilder.AddColumn<string>(
                name: "cuentaDestino",
                table: "Transferencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cuentaOrigen",
                table: "Transferencias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TransferenciaId",
                table: "Cuentas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_TransferenciaId",
                table: "Cuentas",
                column: "TransferenciaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Transferencias_TransferenciaId",
                table: "Cuentas",
                column: "TransferenciaId",
                principalTable: "Transferencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
