namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class CadastrarUsuarioValidation : UsuarioValidation<UsuarioForCreationViewModel>
    {
        public CadastrarUsuarioValidation(UsuarioForCreationViewModel viewModel) 
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
