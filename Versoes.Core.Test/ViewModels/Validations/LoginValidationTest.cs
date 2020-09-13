using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Test.ViewModels.Validations
{
    public class LoginValidationTest
    {
        private LoginViewModel _loginViewModel;

        [SetUp]
        public void Setup()
        {
            _loginViewModel = new LoginViewModel
            {
                Login = "teste",
                Senha = "teste213"
            };
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenLoginIsEmpty()
        {
            _loginViewModel.Login = string.Empty;

            _loginViewModel.Validate();

            var result = _loginViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login é obrigatório");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenPasswordIsEmpty()
        {
            _loginViewModel.Senha = string.Empty;

            _loginViewModel.Validate();

            var result = _loginViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Senha é obrigatório");
        }
    }
}
