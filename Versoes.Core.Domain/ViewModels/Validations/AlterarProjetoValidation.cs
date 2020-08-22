namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class AlterarProjetoValidation : ProjetoValidation<ProjetoForUpdateVireModel>
    {

        public AlterarProjetoValidation(ProjetoForUpdateVireModel viewModel)
            : base(viewModel)
        {
            ValidateId();
            ValidateNome();
        }
    }
}
