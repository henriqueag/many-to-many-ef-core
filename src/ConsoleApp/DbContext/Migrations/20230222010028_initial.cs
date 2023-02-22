using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp.DbContext.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disciplina",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplina", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Estudante",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Matricula = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudante", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstudanteDisciplina",
                columns: table => new
                {
                    EstudanteId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false),
                    Nota = table.Column<double>(type: "REAL", nullable: false),
                    Aprovado = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstudanteDisciplina", x => new { x.EstudanteId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_EstudanteDisciplina_Disciplina_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplina",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstudanteDisciplina_Estudante_EstudanteId",
                        column: x => x.EstudanteId,
                        principalTable: "Estudante",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EstudanteDisciplina_DisciplinaId",
                table: "EstudanteDisciplina",
                column: "DisciplinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EstudanteDisciplina");

            migrationBuilder.DropTable(
                name: "Disciplina");

            migrationBuilder.DropTable(
                name: "Estudante");
        }
    }
}
