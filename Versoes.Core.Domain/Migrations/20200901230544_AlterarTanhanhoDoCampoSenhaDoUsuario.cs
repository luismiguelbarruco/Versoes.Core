using Microsoft.EntityFrameworkCore.Migrations;

namespace Versoes.Core.Domain.Migrations
{
    public partial class AlterarTanhanhoDoCampoSenhaDoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                maxLength: 60
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuario"
            );
        }
    }
}
