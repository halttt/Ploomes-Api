using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ploomers_Advogados.Migrations
{
    /// <inheritdoc />
    public partial class AtualizartabelaAdvogado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Advogados",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Advogados",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Advogados");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Advogados");
        }
    }
}
