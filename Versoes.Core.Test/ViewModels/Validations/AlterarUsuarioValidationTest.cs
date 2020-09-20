using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.ViewModels;
using Versoes.Entities.Models;

namespace Versoes.Core.Test.ValidationsTest
{
    [TestFixture(TestName = "AlterarUsuarioValidation")]
    public class AlterarUsuarioValidationTest
    {
        private UsuarioForUpdateViewModel _usuarioForUpdateViewModel;

        [SetUp]
        public void Setup()
        {
            _usuarioForUpdateViewModel = new UsuarioForUpdateViewModel
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
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenIdIsZero()
        {
            _usuarioForUpdateViewModel.Id = 0;

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Id do usuário inválido");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenNameIsEmpty()
        {
            _usuarioForUpdateViewModel.Nome = string.Empty;

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome é obrigatório");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenNameIsGreaterThan30()
        {
            _usuarioForUpdateViewModel.Nome = "dhasghghghaghdgashdghgdhjghasgdjhagddhasghg";

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome não pode ser maior que 30 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenNameIsLessThan3()
        {
            _usuarioForUpdateViewModel.Nome = "1";

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome deve ter no mínimo 3 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenInitialsIsEmpty()
        {
            _usuarioForUpdateViewModel.Sigla = string.Empty;

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Sigla é obrigatório");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenInitialsIsGreaterThan5()
        {
            _usuarioForUpdateViewModel.Sigla = "weqeqweweqwe";

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Sigla não pode ser maior que 5 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenInitialsIsLessThan2()
        {
            _usuarioForUpdateViewModel.Sigla = "1";

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Sigla deve ter no mínimo 2 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenIdDepartamentIsNull()
        {
            _usuarioForUpdateViewModel.Setor = null;

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Obrigatório informar um setor");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenIdDepartamentIsZero()
        {
            _usuarioForUpdateViewModel.Setor = new Setor { Id = 0 };

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Obrigatório informar um setor com id válido");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenLoginIsEmpty()
        {
            _usuarioForUpdateViewModel.Login = string.Empty;

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login é obrigatório");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenLoginIsGreaterThan20()
        {
            _usuarioForUpdateViewModel.Login = "ghaghdgashdghgdhjghasgdjhagddh";

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login não pode ser maior que 20 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenLoginIsLessThan3()
        {
            _usuarioForUpdateViewModel.Login = "Te";

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login deve ter no mínimo 3 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenPasswordGreaterThan8()
        {
            _usuarioForUpdateViewModel.Senha = "dgashdghgdhj";

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Senha não pode ser maior que 8 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUsuarioForUpdateViewModelWhenPasswordIsLessThan3()
        {
            _usuarioForUpdateViewModel.Senha = "Te";

            _usuarioForUpdateViewModel.Validate();

            var result = _usuarioForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Senha deve ter no mínimo 3 caracteres.");
        }
    }
}
