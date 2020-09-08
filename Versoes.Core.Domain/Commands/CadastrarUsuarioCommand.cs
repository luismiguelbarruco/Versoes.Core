using Versoes.Entities;

namespace Versoes.Core.Domain.Commands
{
    public class CadastrarUsuarioCommand : UsuarioCommand
    {
        public CadastrarUsuarioCommand(string nome, string sigla, int setorId, StatusDeCadastro status, string login, string senha)
        {
            Nome = nome;
            Sigla = sigla;
            SetorId = setorId;
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
            ValidateNovaSenha();

            if (Invalid)
            {
                ValidationResult = new CommandResult(false, "Não foi possivel cadastrar usuário", Notifications);
                return false;
            }

            return true;
        }
    }
}
