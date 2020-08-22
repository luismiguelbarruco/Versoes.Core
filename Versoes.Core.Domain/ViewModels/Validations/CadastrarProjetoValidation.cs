
namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class CadastrarProjetoValidation : ProjetoValidation<ProjetoForCreationViewModel>
    {
        public CadastrarProjetoValidation(ProjetoForCreationViewModel viewModel)
            : base(viewModel)
        {
            ValidateNome();
        }
    }
}
