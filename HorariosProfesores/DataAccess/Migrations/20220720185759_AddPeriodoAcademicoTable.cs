using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddPeriodoAcademicoTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Competencias_Competencia_Nombre_Competencia_Id",
                table: "Competencias");

            migrationBuilder.AddColumn<int>(
                name: "Programa_Id",
                table: "Competencias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PeriodoAcademicos",
                columns: table => new
                {
                    Periodo_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Periodo_FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Periodo_FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Periodo_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoAcademicos", x => x.Periodo_Id);
                });

            migrationBuilder.CreateTable(
                name: "PeriodoAcademicoPrograma",
                columns: table => new
                {
                    PeriodoAcademicosPeriodo_Id = table.Column<int>(type: "int", nullable: false),
                    ProgramasPrograma_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoAcademicoPrograma", x => new { x.PeriodoAcademicosPeriodo_Id, x.ProgramasPrograma_Id });
                    table.ForeignKey(
                        name: "FK_PeriodoAcademicoPrograma_PeriodoAcademicos_PeriodoAcademicosPeriodo_Id",
                        column: x => x.PeriodoAcademicosPeriodo_Id,
                        principalTable: "PeriodoAcademicos",
                        principalColumn: "Periodo_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeriodoAcademicoPrograma_Programas_ProgramasPrograma_Id",
                        column: x => x.ProgramasPrograma_Id,
                        principalTable: "Programas",
                        principalColumn: "Programa_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competencias_Competencia_Nombre_Programa_Id",
                table: "Competencias",
                columns: new[] { "Competencia_Nombre", "Programa_Id" },
                unique: true,
                filter: "[Programa_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Competencias_Programa_Id",
                table: "Competencias",
                column: "Programa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodoAcademicoPrograma_ProgramasPrograma_Id",
                table: "PeriodoAcademicoPrograma",
                column: "ProgramasPrograma_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodoAcademicos_Periodo_Nombre_Periodo_Id",
                table: "PeriodoAcademicos",
                columns: new[] { "Periodo_Nombre", "Periodo_Id" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Competencias_Programas_Programa_Id",
                table: "Competencias",
                column: "Programa_Id",
                principalTable: "Programas",
                principalColumn: "Programa_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competencias_Programas_Programa_Id",
                table: "Competencias");

            migrationBuilder.DropTable(
                name: "PeriodoAcademicoPrograma");

            migrationBuilder.DropTable(
                name: "PeriodoAcademicos");

            migrationBuilder.DropIndex(
                name: "IX_Competencias_Competencia_Nombre_Programa_Id",
                table: "Competencias");

            migrationBuilder.DropIndex(
                name: "IX_Competencias_Programa_Id",
                table: "Competencias");

            migrationBuilder.DropColumn(
                name: "Programa_Id",
                table: "Competencias");

            migrationBuilder.CreateIndex(
                name: "IX_Competencias_Competencia_Nombre_Competencia_Id",
                table: "Competencias",
                columns: new[] { "Competencia_Nombre", "Competencia_Id" },
                unique: true);
        }
    }
}
