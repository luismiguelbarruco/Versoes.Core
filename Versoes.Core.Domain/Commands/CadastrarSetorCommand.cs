using Versoes.Core.Domain.Commands.Validations;
using Versoes.Entities;

namespace Versoes.Core.Domain.Commands
{
    public class CadastrarSetorCommand : SetorCommand
    {
        public CadastrarSetorCommand(string nome, StatusDeCadastro status)
        {
            Nome = nome;
            Status = status;
        }

        public override bool Validate()
        {
            ValidateNome();

            if (Invalid)
            {
                ValidationResult = new CommandResult(false, "Não foi possivel cadastrar setor", Notifications);
                return false;
            }

            return true;
        }
    }


}