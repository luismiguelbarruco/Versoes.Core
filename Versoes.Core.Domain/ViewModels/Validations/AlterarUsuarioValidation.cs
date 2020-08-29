namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class AlterarUsuarioValidation : UsuarioValidation<UsuarioForUpdateViewModel>
    {
        public AlterarUsuarioValidation(UsuarioForUpdateViewModel viewModel) 
            : base(viewModel)
        {
            ValidateNome();
            ValidateSigla();
            ValidateSetor();
            ValidateLogin();
            ValidateSenha();
        }
    }
}
