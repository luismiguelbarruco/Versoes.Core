using Versoes.Entities;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Commands.Validations
{
    public class AlterarUsuarioCommand : UsuarioCommand
    {
        public AlterarUsuarioCommand(int id, string nome, string sigla, Setor setor, StatusDeCadastro status, string login, string senha)
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
            ValidateId();
            ValidateSigla();
            ValidateNome();
            ValidateSetor();
            ValidateLogin();
            ValidateSenha();

            if (Invalid)
            {
                ValidationResult = new CommandResult(false, "Não foi possivel alterar usuário", Notifications);
                return false;
            }

            return true;
        }
    }
}
