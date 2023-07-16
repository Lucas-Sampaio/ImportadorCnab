using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ImportadorCNAB.Infra.Migrations
{
    /// <inheritdoc />
    public partial class migracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeLoja = table.Column<string>(type: "varchar(200)", nullable: false),
                    Nome = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cpf_Numero = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoTransacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Codigo = table.Column<int>(type: "int", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(200)", nullable: false),
                    Natureza = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoTransacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CartaoUtilizadoNumero = table.Column<string>(type: "varchar(200)", nullable: false),
                    TipoTransacaoId = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transacao_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Transacao_TipoTransacao_TipoTransacaoId",
                        column: x => x.TipoTransacaoId,
                        principalTable: "TipoTransacao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TipoTransacao",
                columns: new[] { "Id", "Codigo", "Descricao", "Natureza" },
                values: new object[,]
                {
                    { 1, 1, "Debito", "Entrada" },
                    { 2, 2, "Boleto", "Saida" },
                    { 3, 3, "Financiamento", "Saida" },
                    { 4, 4, "Crédito", "Entrada" },
                    { 5, 5, "Recebimento Empréstimo", "Entrada" },
                    { 6, 6, "Vendas", "Entrada" },
                    { 7, 7, "Recebimento TED", "Entrada" },
                    { 8, 8, "Recebimento DOC", "Entrada" },
                    { 9, 9, "Aluguel", "Saida" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_Cpf_Numero",
                table: "Clientes",
                column: "Cpf_Numero",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_ClienteId",
                table: "Transacao",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Transacao_TipoTransacaoId",
                table: "Transacao",
                column: "TipoTransacaoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacao");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "TipoTransacao");
        }
    }
}
