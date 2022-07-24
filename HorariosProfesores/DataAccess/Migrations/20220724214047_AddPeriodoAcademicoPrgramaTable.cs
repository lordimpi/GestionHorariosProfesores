using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddPeriodoAcademicoPrgramaTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Competencias_Competencia_Nombre_Competencia_Id",
                table: "Competencias");

            migrationBuilder.AddColumn<int>(
                name: "PeriodoAcademicoPeriodo_Id",
                table: "Programas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Programa_Id",
                table: "Competencias",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Docentes",
                columns: table => new
                {
                    Docente_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Docente_Nombres = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Docente_Apellidos = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Docente_TipoIdentificacion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Docente_Identificacion = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Docente_Tipo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Docente_TipoContrato = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Docente_Area = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Docentes", x => x.Docente_Id);
                });

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
                name: "PeriodoAcademicoProgramas",
                columns: table => new
                {
                    PeriodoAcademicoId = table.Column<int>(type: "int", nullable: false),
                    ProgramaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeriodoAcademicoProgramas", x => new { x.PeriodoAcademicoId, x.ProgramaId });
                    table.ForeignKey(
                        name: "FK_PeriodoAcademicoProgramas_PeriodoAcademicos_PeriodoAcademicoId",
                        column: x => x.PeriodoAcademicoId,
                        principalTable: "PeriodoAcademicos",
                        principalColumn: "Periodo_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeriodoAcademicoProgramas_Programas_ProgramaId",
                        column: x => x.ProgramaId,
                        principalTable: "Programas",
                        principalColumn: "Programa_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Programas_PeriodoAcademicoPeriodo_Id",
                table: "Programas",
                column: "PeriodoAcademicoPeriodo_Id");

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
                name: "IX_Docentes_Docente_Identificacion",
                table: "Docentes",
                column: "Docente_Identificacion",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PeriodoAcademicoProgramas_ProgramaId",
                table: "PeriodoAcademicoProgramas",
                column: "ProgramaId");

            migrationBuilder.CreateIndex(
                name: "IX_PeriodoAcademicos_Periodo_Nombre",
                table: "PeriodoAcademicos",
                column: "Periodo_Nombre",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Competencias_Programas_Programa_Id",
                table: "Competencias",
                column: "Programa_Id",
                principalTable: "Programas",
                principalColumn: "Programa_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Programas_PeriodoAcademicos_PeriodoAcademicoPeriodo_Id",
                table: "Programas",
                column: "PeriodoAcademicoPeriodo_Id",
                principalTable: "PeriodoAcademicos",
                principalColumn: "Periodo_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competencias_Programas_Programa_Id",
                table: "Competencias");

            migrationBuilder.DropForeignKey(
                name: "FK_Programas_PeriodoAcademicos_PeriodoAcademicoPeriodo_Id",
                table: "Programas");

            migrationBuilder.DropTable(
                name: "Docentes");

            migrationBuilder.DropTable(
                name: "PeriodoAcademicoProgramas");

            migrationBuilder.DropTable(
                name: "PeriodoAcademicos");

            migrationBuilder.DropIndex(
                name: "IX_Programas_PeriodoAcademicoPeriodo_Id",
                table: "Programas");

            migrationBuilder.DropIndex(
                name: "IX_Competencias_Competencia_Nombre_Programa_Id",
                table: "Competencias");

            migrationBuilder.DropIndex(
                name: "IX_Competencias_Programa_Id",
                table: "Competencias");

            migrationBuilder.DropColumn(
                name: "PeriodoAcademicoPeriodo_Id",
                table: "Programas");

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
