using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Corrupcion.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Escandalos",
                columns: table => new
                {
                    IdEscandalo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdGobierno = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Escandalos", x => x.IdEscandalo);
                });

            migrationBuilder.CreateTable(
                name: "Partidos",
                columns: table => new
                {
                    IdPartido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePartido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreAbreviado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidos", x => x.IdPartido);
                });

            migrationBuilder.CreateTable(
                name: "Presidentes",
                columns: table => new
                {
                    IdPresidente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePresidente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreVicePresidente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdPartido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presidentes", x => x.IdPresidente);
                });

            migrationBuilder.CreateTable(
                name: "Gobiernos",
                columns: table => new
                {
                    IdGobierno = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPartido = table.Column<int>(type: "int", nullable: false),
                    IdPresidente = table.Column<int>(type: "int", nullable: false),
                    PresidenteIdPresidente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gobiernos", x => x.IdGobierno);
                    table.ForeignKey(
                        name: "FK_Gobiernos_Presidentes_PresidenteIdPresidente",
                        column: x => x.PresidenteIdPresidente,
                        principalTable: "Presidentes",
                        principalColumn: "IdPresidente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gobiernos_PresidenteIdPresidente",
                table: "Gobiernos",
                column: "PresidenteIdPresidente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Escandalos");

            migrationBuilder.DropTable(
                name: "Gobiernos");

            migrationBuilder.DropTable(
                name: "Partidos");

            migrationBuilder.DropTable(
                name: "Presidentes");
        }
    }
}
