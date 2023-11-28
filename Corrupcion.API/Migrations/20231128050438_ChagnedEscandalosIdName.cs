using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corrupcion.API.Migrations
{
    /// <inheritdoc />
    public partial class ChagnedEscandalosIdName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdEscandalo",
                table: "Escandalos",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Escandalos",
                newName: "IdEscandalo");
        }
    }
}
