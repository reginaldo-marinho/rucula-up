using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuculaX.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class IniciandoIntegrante : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IntegranteModel",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Batizado = table.Column<bool>(type: "boolean", nullable: false),
                    EstadoCivil = table.Column<byte>(type: "smallint", nullable: false),
                    ServeNaIgreja = table.Column<bool>(type: "boolean", nullable: false),
                    Ministerio = table.Column<string>(type: "text", nullable: false),
                    TelefoneCelular = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegranteModel", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IntegranteModel");
        }
    }
}
