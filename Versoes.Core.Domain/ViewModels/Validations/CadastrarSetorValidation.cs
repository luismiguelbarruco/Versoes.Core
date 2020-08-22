
namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class CadastrarSetorValidation : SetorValidation<SetorForCreationViewModel>
    {
        public CadastrarSetorValidation(SetorForCreationViewModel viewModel) 
            : base(viewModel)
        {
            ValidateNome();
        }
    }
}
