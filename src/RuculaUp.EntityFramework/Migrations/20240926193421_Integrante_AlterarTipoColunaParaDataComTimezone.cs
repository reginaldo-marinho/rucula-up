using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RuculaUp.EntityFramework.Migrations
{
    /// <inheritdoc />
    public partial class Integrante_AlterarTipoColunaParaDataComTimezone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
              migrationBuilder.AlterColumn<DateTime>(
                name: "DataDeNascimento",
                table: "Integrante",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
