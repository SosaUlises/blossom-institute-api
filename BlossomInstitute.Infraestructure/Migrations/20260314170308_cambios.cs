using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BlossomInstitute.Infraestructure.Migrations
{
    /// <inheritdoc />
    public partial class cambios : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EntregaFeedbacks_EntregaId_EsVigente",
                table: "EntregaFeedbacks");

            migrationBuilder.DropColumn(
                name: "ArchivoCorregidoNombre",
                table: "EntregaFeedbacks");

            migrationBuilder.DropColumn(
                name: "ArchivoCorregidoUrl",
                table: "EntregaFeedbacks");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "EntregaAdjuntos",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAtUtc",
                table: "EntregaAdjuntos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "SizeBytes",
                table: "EntregaAdjuntos",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StorageKey",
                table: "EntregaAdjuntos",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StorageProvider",
                table: "EntregaAdjuntos",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FeedbackEntregaAdjuntos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeedbackEntregaId = table.Column<int>(type: "integer", nullable: false),
                    Tipo = table.Column<int>(type: "integer", nullable: false),
                    Url = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Nombre = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    StorageProvider = table.Column<int>(type: "integer", nullable: true),
                    StorageKey = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    ContentType = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    SizeBytes = table.Column<long>(type: "bigint", nullable: true),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedbackEntregaAdjuntos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedbackEntregaAdjuntos_EntregaFeedbacks_FeedbackEntregaId",
                        column: x => x.FeedbackEntregaId,
                        principalTable: "EntregaFeedbacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntregaAdjuntos_EntregaId_StorageKey",
                table: "EntregaAdjuntos",
                columns: new[] { "EntregaId", "StorageKey" });

            migrationBuilder.CreateIndex(
                name: "IX_EntregaAdjuntos_StorageKey",
                table: "EntregaAdjuntos",
                column: "StorageKey");

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackEntregaAdjuntos_FeedbackEntregaId_StorageKey",
                table: "FeedbackEntregaAdjuntos",
                columns: new[] { "FeedbackEntregaId", "StorageKey" });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackEntregaAdjuntos_FeedbackEntregaId_Tipo",
                table: "FeedbackEntregaAdjuntos",
                columns: new[] { "FeedbackEntregaId", "Tipo" });

            migrationBuilder.CreateIndex(
                name: "IX_FeedbackEntregaAdjuntos_StorageKey",
                table: "FeedbackEntregaAdjuntos",
                column: "StorageKey");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeedbackEntregaAdjuntos");

            migrationBuilder.DropIndex(
                name: "IX_EntregaAdjuntos_EntregaId_StorageKey",
                table: "EntregaAdjuntos");

            migrationBuilder.DropIndex(
                name: "IX_EntregaAdjuntos_StorageKey",
                table: "EntregaAdjuntos");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "EntregaAdjuntos");

            migrationBuilder.DropColumn(
                name: "CreatedAtUtc",
                table: "EntregaAdjuntos");

            migrationBuilder.DropColumn(
                name: "SizeBytes",
                table: "EntregaAdjuntos");

            migrationBuilder.DropColumn(
                name: "StorageKey",
                table: "EntregaAdjuntos");

            migrationBuilder.DropColumn(
                name: "StorageProvider",
                table: "EntregaAdjuntos");

            migrationBuilder.AddColumn<string>(
                name: "ArchivoCorregidoNombre",
                table: "EntregaFeedbacks",
                type: "character varying(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArchivoCorregidoUrl",
                table: "EntregaFeedbacks",
                type: "character varying(2000)",
                maxLength: 2000,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EntregaFeedbacks_EntregaId_EsVigente",
                table: "EntregaFeedbacks",
                columns: new[] { "EntregaId", "EsVigente" });
        }
    }
}
