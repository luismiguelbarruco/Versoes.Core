using Flunt.Notifications;
using Flunt.Validations;

namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class LoginValidation : Notifiable
    {
        private readonly LoginViewModel _loginViewModel;
        
        public LoginValidation(LoginViewModel viewModel)
        {
            _loginViewModel = viewModel;
            ValidateLogin();
            ValidateSenha();
        }

        protected void ValidateLogin()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_loginViewModel.Login, nameof(_loginViewModel.Login), "Login é obrigatório")
            );
        }

        protected void ValidateSenha()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_loginViewModel.Senha, nameof(_loginViewModel.Senha), "Senha é obrigatório")
            );
        }
    }
}