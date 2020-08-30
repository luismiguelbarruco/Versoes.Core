using Flunt.Notifications;
using Flunt.Validations;

namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class LoginValidation : Notifiable
    {
        private readonly LoginViewModel _loginViewModel;
        
        public LoginValidation(LoginViewModel viewModel) => _loginViewModel = viewModel;
        protected void ValidateLogin()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_loginViewModel.Login, nameof(_loginViewModel.Login), "Login é obrigatório")
                .HasMaxLen(_loginViewModel.Login, 20, nameof(_loginViewModel.Login), "Login não pode ser maior que 20 caracteres.")
            );
        }

        protected void ValidateSenha()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_loginViewModel.Senha, nameof(_loginViewModel.Senha), "Senha é obrigatório")
                .HasMaxLen(_loginViewModel.Senha, 20, nameof(_loginViewModel.Senha), "Senha não pode ser maior que 20 caracteres.")
            );
        }
    }
}