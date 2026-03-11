using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlossomInstitute.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class calificaciondetalles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Alumnos_AlumnoId",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Cursos_CursoId",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Entregas_EntregaId",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Tareas_TareaId",
                table: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_CursoId",
                table: "Calificaciones");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Calificaciones",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<decimal>(
                name: "Nota",
                table: "Calificaciones",
                type: "numeric(5,2)",
                precision: 5,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Calificaciones",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TieneDetalleSkills",
                table: "Calificaciones",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CalificacionDetalles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CalificacionId = table.Column<int>(type: "integer", nullable: false),
                    Skill = table.Column<int>(type: "integer", nullable: false),
                    PuntajeObtenido = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    PuntajeMaximo = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalificacionDetalles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalificacionDetalles_Calificaciones_CalificacionId",
                        column: x => x.CalificacionId,
                        principalTable: "Calificaciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_CursoId_AlumnoId_Archivado",
                table: "Calificaciones",
                columns: new[] { "CursoId", "AlumnoId", "Archivado" });

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_CursoId_AlumnoId_Fecha",
                table: "Calificaciones",
                columns: new[] { "CursoId", "AlumnoId", "Fecha" });

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_CursoId_AlumnoId_TareaId_EntregaId_Archivado",
                table: "Calificaciones",
                columns: new[] { "CursoId", "AlumnoId", "TareaId", "EntregaId", "Archivado" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_CursoId_AlumnoId_Tipo_Archivado",
                table: "Calificaciones",
                columns: new[] { "CursoId", "AlumnoId", "Tipo", "Archivado" });

            migrationBuilder.CreateIndex(
                name: "IX_CalificacionDetalles_CalificacionId_Skill",
                table: "CalificacionDetalles",
                columns: new[] { "CalificacionId", "Skill" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Alumnos_AlumnoId",
                table: "Calificaciones",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Cursos_CursoId",
                table: "Calificaciones",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Entregas_EntregaId",
                table: "Calificaciones",
                column: "EntregaId",
                principalTable: "Entregas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Tareas_TareaId",
                table: "Calificaciones",
                column: "TareaId",
                principalTable: "Tareas",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Alumnos_AlumnoId",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Cursos_CursoId",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Entregas_EntregaId",
                table: "Calificaciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Calificaciones_Tareas_TareaId",
                table: "Calificaciones");

            migrationBuilder.DropTable(
                name: "CalificacionDetalles");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_CursoId_AlumnoId_Archivado",
                table: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_CursoId_AlumnoId_Fecha",
                table: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_CursoId_AlumnoId_TareaId_EntregaId_Archivado",
                table: "Calificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Calificaciones_CursoId_AlumnoId_Tipo_Archivado",
                table: "Calificaciones");

            migrationBuilder.DropColumn(
                name: "TieneDetalleSkills",
                table: "Calificaciones");

            migrationBuilder.AlterColumn<string>(
                name: "Titulo",
                table: "Calificaciones",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<decimal>(
                name: "Nota",
                table: "Calificaciones",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(5,2)",
                oldPrecision: 5,
                oldScale: 2);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "Calificaciones",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calificaciones_CursoId",
                table: "Calificaciones",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Alumnos_AlumnoId",
                table: "Calificaciones",
                column: "AlumnoId",
                principalTable: "Alumnos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Cursos_CursoId",
                table: "Calificaciones",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Entregas_EntregaId",
                table: "Calificaciones",
                column: "EntregaId",
                principalTable: "Entregas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Calificaciones_Tareas_TareaId",
                table: "Calificaciones",
                column: "TareaId",
                principalTable: "Tareas",
                principalColumn: "Id");
        }
    }
}
