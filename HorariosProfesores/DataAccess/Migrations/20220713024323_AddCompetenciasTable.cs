using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddCompetenciasTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Competencias",
                columns: table => new
                {
                    Competencia_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Competencia_Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competencias", x => x.Competencia_Id);
                });

            migrationBuilder.CreateTable(
                name: "Programas",
                columns: table => new
                {
                    Programa_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Programa_Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsActivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programas", x => x.Programa_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competencias_Competencia_Nombre_Competencia_Id",
                table: "Competencias",
                columns: new[] { "Competencia_Nombre", "Competencia_Id" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Programas_Programa_Nombre",
                table: "Programas",
                column: "Programa_Nombre",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Competencias");

            migrationBuilder.DropTable(
                name: "Programas");
        }
    }
}
