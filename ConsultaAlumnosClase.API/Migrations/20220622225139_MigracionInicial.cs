using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsultaAlumnosClase.API.Migrations
{
    public partial class MigracionInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Cuatrimestre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false),
                    Apellido = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    NombreUsuario = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoMateria",
                columns: table => new
                {
                    AlumnosId = table.Column<int>(type: "INTEGER", nullable: false),
                    MateriasEnCursoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoMateria", x => new { x.AlumnosId, x.MateriasEnCursoId });
                    table.ForeignKey(
                        name: "FK_AlumnoMateria_Materias_MateriasEnCursoId",
                        column: x => x.MateriasEnCursoId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlumnoMateria_Usuario_AlumnosId",
                        column: x => x.AlumnosId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consultas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: false),
                    Descripcion = table.Column<string>(type: "TEXT", nullable: false),
                    ProfesorAsignadoId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlumnoId = table.Column<int>(type: "INTEGER", nullable: false),
                    MateriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    EstadoConsulta = table.Column<int>(type: "INTEGER", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    FechaFinalizacion = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FechaUltimaModificacion = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consultas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consultas_Materias_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Usuario_AlumnoId",
                        column: x => x.AlumnoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consultas_Usuario_ProfesorAsignadoId",
                        column: x => x.ProfesorAsignadoId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MateriaProfesor",
                columns: table => new
                {
                    MateriasAsignadasId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProfesoresId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaProfesor", x => new { x.MateriasAsignadasId, x.ProfesoresId });
                    table.ForeignKey(
                        name: "FK_MateriaProfesor_Materias_MateriasAsignadasId",
                        column: x => x.MateriasAsignadasId,
                        principalTable: "Materias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MateriaProfesor_Usuario_ProfesoresId",
                        column: x => x.ProfesoresId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Respuestas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Mensaje = table.Column<string>(type: "TEXT", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreadorId = table.Column<int>(type: "INTEGER", nullable: false),
                    ConsultaId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respuestas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respuestas_Consultas_ConsultaId",
                        column: x => x.ConsultaId,
                        principalTable: "Consultas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Respuestas_Usuario_CreadorId",
                        column: x => x.CreadorId,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "Cuatrimestre", "Nombre" },
                values: new object[] { 1, "Tercer", "Programación 3" });

            migrationBuilder.InsertData(
                table: "Materias",
                columns: new[] { "Id", "Cuatrimestre", "Nombre" },
                values: new object[] { 2, "Tercer", "Programación 4" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "Nombre", "NombreUsuario", "Password" },
                values: new object[] { 1, "Bologna", "Alumno", "nbologna31@gmail.com", "Nicolas", "nbologna_alumno", "123456" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "Nombre", "NombreUsuario", "Password" },
                values: new object[] { 2, "Perez", "Alumno", "Jperez@gmail.com", "Juan", "jperez", "123456" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "Nombre", "NombreUsuario", "Password" },
                values: new object[] { 3, "Garcia", "Alumno", "pgarcia@gmail.com", "Pedro", "pgarcia", "123456" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "Nombre", "NombreUsuario", "Password" },
                values: new object[] { 4, "Bologna", "Profesor", "nbologna31@gmail.com", "Nicolas", "nbologna_profesor", "123456" });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Apellido", "Discriminator", "Email", "Nombre", "NombreUsuario", "Password" },
                values: new object[] { 5, "Paez", "Profesor", "ppaez@gmail.com", "Pablo", "ppaez", "123456" });

            migrationBuilder.InsertData(
                table: "AlumnoMateria",
                columns: new[] { "AlumnosId", "MateriasEnCursoId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "AlumnoMateria",
                columns: new[] { "AlumnosId", "MateriasEnCursoId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "MateriaProfesor",
                columns: new[] { "MateriasAsignadasId", "ProfesoresId" },
                values: new object[] { 1, 4 });

            migrationBuilder.InsertData(
                table: "MateriaProfesor",
                columns: new[] { "MateriasAsignadasId", "ProfesoresId" },
                values: new object[] { 1, 5 });

            migrationBuilder.InsertData(
                table: "MateriaProfesor",
                columns: new[] { "MateriasAsignadasId", "ProfesoresId" },
                values: new object[] { 2, 4 });

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoMateria_MateriasEnCursoId",
                table: "AlumnoMateria",
                column: "MateriasEnCursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_AlumnoId",
                table: "Consultas",
                column: "AlumnoId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_MateriaId",
                table: "Consultas",
                column: "MateriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_ProfesorAsignadoId",
                table: "Consultas",
                column: "ProfesorAsignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_MateriaProfesor_ProfesoresId",
                table: "MateriaProfesor",
                column: "ProfesoresId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_ConsultaId",
                table: "Respuestas",
                column: "ConsultaId");

            migrationBuilder.CreateIndex(
                name: "IX_Respuestas_CreadorId",
                table: "Respuestas",
                column: "CreadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoMateria");

            migrationBuilder.DropTable(
                name: "MateriaProfesor");

            migrationBuilder.DropTable(
                name: "Respuestas");

            migrationBuilder.DropTable(
                name: "Consultas");

            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
