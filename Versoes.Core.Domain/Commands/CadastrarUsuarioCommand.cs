using Versoes.Entities;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Commands
{
    public class CadastrarUsuarioCommand : UsuarioCommand
    {
        public CadastrarUsuarioCommand(int id, string nome, string sigla, Setor setor, StatusDeCadastro status, string login, string senha)
        {
            Id = id;
            Nome = nome;
            Sigla = sigla;
            Setor = setor;
            Status = status;
            Login = login;
            Senha = senha;
        }

        public override bool Validate()
        {
            ValidateSigla();
            ValidateNome();
            ValidateSetor();
            ValidateLogin();
            ValidateSenha();

            if (Invalid)
            {
                ValidationResult = new CommandResult(false, "Não foi possivel cadastrar usuário", Notifications);
                return false;
            }

            return true;
        }
    }
}
