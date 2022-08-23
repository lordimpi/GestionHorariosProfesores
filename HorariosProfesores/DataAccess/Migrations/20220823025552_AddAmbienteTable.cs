using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddAmbienteTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ambientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ubicacion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoAmbiente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Capacidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ambientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Horario_Dia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horario_Hora_Inicio = table.Column<int>(type: "int", nullable: false),
                    Horario_Hora_Fin = table.Column<int>(type: "int", nullable: false),
                    Horario_Duracion = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PeriodoAcademicoId = table.Column<int>(type: "int", nullable: false),
                    AmbienteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Horarios_Ambientes_AmbienteId",
                        column: x => x.AmbienteId,
                        principalTable: "Ambientes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Horarios_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Horarios_PeriodoAcademicos_PeriodoAcademicoId",
                        column: x => x.PeriodoAcademicoId,
                        principalTable: "PeriodoAcademicos",
                        principalColumn: "Periodo_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_AmbienteId",
                table: "Horarios",
                column: "AmbienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_PeriodoAcademicoId",
                table: "Horarios",
                column: "PeriodoAcademicoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Horarios_UserId",
                table: "Horarios",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Horarios");

            migrationBuilder.DropTable(
                name: "Ambientes");
        }
    }
}
