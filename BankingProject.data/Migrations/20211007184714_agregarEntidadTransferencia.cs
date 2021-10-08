using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingProject.Migrations
{
    public partial class agregarEntidadTransferencia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cuentas_UserId",
                table: "Cuentas");

            migrationBuilder.AddColumn<int>(
                name: "TransferenciaId",
                table: "Cuentas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Transferencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cuentaOrigen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cuentaDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    montoAPagar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    concepto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transferencias", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_TransferenciaId",
                table: "Cuentas",
                column: "TransferenciaId");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UserId",
                table: "Cuentas",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cuentas_Transferencias_TransferenciaId",
                table: "Cuentas",
                column: "TransferenciaId",
                principalTable: "Transferencias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cuentas_Transferencias_TransferenciaId",
                table: "Cuentas");

            migrationBuilder.DropTable(
                name: "Transferencias");

            migrationBuilder.DropIndex(
                name: "IX_Cuentas_TransferenciaId",
                table: "Cuentas");

            migrationBuilder.DropIndex(
                name: "IX_Cuentas_UserId",
                table: "Cuentas");

            migrationBuilder.DropColumn(
                name: "TransferenciaId",
                table: "Cuentas");

            migrationBuilder.CreateIndex(
                name: "IX_Cuentas_UserId",
                table: "Cuentas",
                column: "UserId");
        }
    }
}
