using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuculaUp.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Rua = table.Column<string>(type: "text", nullable: false),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Integrante",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Batizado = table.Column<bool>(type: "boolean", nullable: false),
                    EstadoCivil = table.Column<byte>(type: "smallint", nullable: false),
                    ServeNaIgreja = table.Column<bool>(type: "boolean", nullable: false),
                    Ministerio = table.Column<string>(type: "text", nullable: false),
                    TelefoneCelular = table.Column<string>(type: "text", nullable: false),
                    EnderecoId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Integrante", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Integrante_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Integrante_EnderecoId",
                table: "Integrante",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Integrante");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
