using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ImportadorCNAB.Infra.Migrations
{
    /// <inheritdoc />
    public partial class removidocpfUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Clientes_Cpf_Numero",
                table: "Clientes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cpf_Numero",
                table: "Clientes",
                column: "Cpf_Numero",
                unique: true);
        }
    }
}
