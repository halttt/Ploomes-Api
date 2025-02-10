using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ploomers_Advogados.Migrations
{
    /// <inheritdoc />
    public partial class Subindoparaazure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Advogados",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advogados", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Processos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoProcesso = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataOcorrencia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdvogadoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Processos_Advogados_AdvogadoId",
                        column: x => x.AdvogadoId,
                        principalTable: "Advogados",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Processos_AdvogadoId",
                table: "Processos",
                column: "AdvogadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Processos");

            migrationBuilder.DropTable(
                name: "Advogados");
        }
    }
}
