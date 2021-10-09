using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingProject.Migrations
{
    public partial class deleteentitytransacciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacciones");

            migrationBuilder.AddColumn<bool>(
                name: "Estado",
                table: "Transferencias",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Fecha",
                table: "Transferencias",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Transferencias");

            migrationBuilder.DropColumn(
                name: "Fecha",
                table: "Transferencias");

            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CuentaId = table.Column<long>(type: "bigint", nullable: true),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getdate()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacciones_Cuentas_CuentaId",
                        column: x => x.CuentaId,
                        principalTable: "Cuentas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transacciones_CuentaId",
                table: "Transacciones",
                column: "CuentaId");
        }
    }
}
