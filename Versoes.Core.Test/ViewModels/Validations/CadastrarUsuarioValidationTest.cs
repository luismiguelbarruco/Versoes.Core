using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.ViewModels;
using Versoes.Entities.Models;

namespace Versoes.Core.Test.ValidationsTest
{
    public class CadastrarUsuarioValidationTest
    {
        private UsuarioForCreationViewModel _usuarioForCreationViewModel;

        [SetUp]
        public void Setup()
        {
            _usuarioForCreationViewModel = new UsuarioForCreationViewModel
            {
                Id = 1,
                Nome = "Teste",
                Login = "teste",
                Sigla = "DV",
                Setor = new Setor { Id = 1 },
                Senha = "senha"
            };
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenNameIsEmpty()
        {
            _usuarioForCreationViewModel.Nome = string.Empty;

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome é obrigatório");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenNameIsGreaterThan30()
        {
            _usuarioForCreationViewModel.Nome = "dhasghghghaghdgashdghgdhjghasgdjhagddhasghg";

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome não pode ser maior que 30 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenNameIsLessThan3()
        {
            _usuarioForCreationViewModel.Nome = "1";

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome deve ter no mínimo 3 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenInitialsIsEmpty()
        {
            _usuarioForCreationViewModel.Sigla = string.Empty;

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Sigla é obrigatório");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenInitialsIsGreaterThan5()
        {
            _usuarioForCreationViewModel.Sigla = "weqeqweweqwe";

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Sigla não pode ser maior que 5 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenInitialsIsLessThan2()
        {
            _usuarioForCreationViewModel.Sigla = "1";

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Sigla deve ter no mínimo 2 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenIdDepartamentIsNull()
        {
            _usuarioForCreationViewModel.Setor = null;

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Obrigatório informar um setor");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenIdDepartamentIsZero()
        {
            _usuarioForCreationViewModel.Setor = new Setor { Id = 0 };

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Obrigatório informar um setor com id válido");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenLoginIsEmpty()
        {
            _usuarioForCreationViewModel.Login = string.Empty;

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login é obrigatório");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenLoginIsGreaterThan20()
        {
            _usuarioForCreationViewModel.Login = "ghaghdgashdghgdhjghasgdjhagddh";

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login não pode ser maior que 20 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenLoginIsLessThan3()
        {
            _usuarioForCreationViewModel.Login = "Te";

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login deve ter no mínimo 3 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenPasswordIsEmpty()
        {
            _usuarioForCreationViewModel.Senha = string.Empty;

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Senha é obrigatório");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenPasswordGreaterThan8()
        {
            _usuarioForCreationViewModel.Senha = "dgashdghgdhj";

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Senha não pode ser maior que 8 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForCreationViewModelWhenPasswordIsLessThan3()
        {
            _usuarioForCreationViewModel.Senha = "Te";

            _usuarioForCreationViewModel.Validate();

            var result = _usuarioForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Senha deve ter no mínimo 3 caracteres.");
        }
    }
}
