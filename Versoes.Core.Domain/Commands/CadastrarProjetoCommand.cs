using Versoes.Core.Domain.ValueObjects;

namespace Versoes.Core.Domain.Commands
{
    public class CadastrarProjetoCommand : ProjetoCommand
    {
        public CadastrarProjetoCommand(string nome, StatusDeCadastro status)
        {
            Nome = nome;
            Status = status;
        }

        public override bool Validate()
        {
            ValidateNome();

            if (Invalid)
            {
                ValidationResult = new CommandResult(false, "Não foi possivel cadastrar projeto", Notifications);
                return false;
            }

            return true;
        }
    }
}
