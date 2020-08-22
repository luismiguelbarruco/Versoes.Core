namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class AlterarProjetoValidation : ProjetoValidation<ProjetoForUpdateViewModel>
    {

        public AlterarProjetoValidation(ProjetoForUpdateViewModel viewModel)
            : base(viewModel)
        {
            ValidateId();
            ValidateNome();
        }
    }
}
