using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuculaUp.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Integrante_AlterarTipoColunaParaData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeNascimento",
                table: "Integrante",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            
        }
    }
}
