using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Diagnostics.CodeAnalysis;

namespace Versoes.Core.Domain.Migrations
{
    [ExcludeFromCodeCoverage]
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projeto",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(maxLength: 100, nullable: false),
                    Status = table.Column<byte>(nullable: false),
                    Sigla = table.Column<string>(maxLength: 20, nullable: false),
                    Login = table.Column<string>(maxLength: 20, nullable: false),
                    Senha = table.Column<string>(maxLength: 20, nullable: false),
                    SetorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Setor_SetorId",
                        column: x => x.SetorId,
                        principalTable: "Setor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Setor",
                columns: new[] { "Id", "Nome", "Status" },
                values: new object[,]
                {
                    { 1, "Desenvolvimento", (byte)0 },
                    { 2, "Suporte", (byte)0 },
                    { 3, "Teste", (byte)0 },
                    { 4, "Financeiro", (byte)0 },
                    { 5, "Admin", (byte)0 }
                });

            migrationBuilder.InsertData(
                table: "Usuario",
                columns: new[] { "Id", "Login", "Nome", "Senha", "SetorId", "Sigla", "Status" },
                values: new object[] { 1, "admin", "Administrador", "admin123", 5, "ADM", (byte)0 });

            migrationBuilder.CreateIndex(
                name: "IX_Projeto_Nome",
                table: "Projeto",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Setor_Nome",
                table: "Setor",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Id",
                table: "Usuario",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Login",
                table: "Usuario",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Nome",
                table: "Usuario",
                column: "Nome",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_SetorId",
                table: "Usuario",
                column: "SetorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Projeto");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Setor");
        }
    }
}
