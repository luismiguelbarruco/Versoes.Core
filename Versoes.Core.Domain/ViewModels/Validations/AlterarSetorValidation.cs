namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class AlterarSetorValidation : SetorValidation<SetorForUpdateViewModel>
    {

        public AlterarSetorValidation(SetorForUpdateViewModel viewModel) 
            : base(viewModel)
        {
            ValidateId();
            ValidateNome();
        }
    }
}
