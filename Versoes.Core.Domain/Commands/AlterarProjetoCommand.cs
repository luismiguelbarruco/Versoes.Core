using Versoes.Core.Domain.Commands.Validations;
using Versoes.Entities;

namespace Versoes.Core.Domain.Commands
{
    public class AlterarProjetoCommand : ProjetoCommand
    {
        public AlterarProjetoCommand(int id, string nome, StatusDeCadastro status)
        {
            Id = id;
            Nome = nome;
            Status = status;
        }

        public override bool Validate()
        {
            ValidateId();
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
