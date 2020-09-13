using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.Commands;
using Versoes.Entities;

namespace Versoes.Core.Test.Commands
{
    public class AlterarUsuarioCommandTest
    {
        [Test]
        public void ShouldInvalidateAlterarUsuarioCommandWhenIdIsZero()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(0, "teste", "FFF", 1, StatusDeCadastro.Normal, "luism", "teste123");

            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Id do usuário inválido");
        }

        [Test]
        public void ShouldInvalidateAlterarUsuarioCommandWhenNameIsEmpty()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(1, string.Empty, "FFF", 1, StatusDeCadastro.Normal, "luism", "teste123");

            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome é obrigatório");
        }

        [Test]
        public void ShouldInvalidateAlterarUsuarioCommandWhenNameIsGreaterThan30()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(1, "dhasghghghaghdgashdghgdhjghasgdjhagddhasghg", "teste", 1, StatusDeCadastro.Normal, "luism", "teste123");
            
            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome não pode ser maior que 30 caracteres.");
        }

        [Test]
        public void ShouldInvalidateAlterarUsuarioCommandWhenNameIsLessThan3()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(1, "an", "tt", 1, StatusDeCadastro.Normal, "luism", "teste123");

            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome deve ter no mínimo 3 caracteres.");
        }

        [Test]
        public void ShouldInvalidateAlterarUsuarioCommandWhenInitialsIsEmpty()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(1, "teste", "", 1, StatusDeCadastro.Normal, "luism", "teste123");

            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Sigla é obrigatório");
        }

        [Test]
        public void ShouldInvalidateAlterarUsuarioCommandWhenInitialsIsGreaterThan5()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(1, "teste", "FFFFFD", 1, StatusDeCadastro.Normal, "luism", "teste123");

            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Sigla não pode ser maior que 5 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUpdateUserWhenInitialsIsLessThan2()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(1, "teste", "F", 1, StatusDeCadastro.Normal, "luism", "teste123");

            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Sigla deve ter no mínimo 2 caracteres.");
        }

        [Test]
        public void ShouldInvalidateAlterarUsuarioCommandWhenIdDepartamentIsZero()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(1, "teste", "FFF", 0, StatusDeCadastro.Normal, "", "teste123");

            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Obrigatório informar um setor com id válido");
        }

        [Test]
        public void ShouldInvalidateAlterarUsuarioCommandWhenLoginIsEmpty()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(1, "teste", "FFF", 1, StatusDeCadastro.Normal, "", "teste123");

            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login é obrigatório");
        }

        [Test]
        public void ShouldInvalidateAlterarUsuarioCommandWhenLoginIsGreaterThan20()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(1, "teste", "FFF", 1, StatusDeCadastro.Normal, "ssluismsfsffsfsfdsfsdffd", "teste123");

            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login não pode ser maior que 20 caracteres.");
        }

        [Test]
        public void ShouldInvalidateAlterarUsuarioCommandWhenLoginIsLessThan3()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(1, "teste", "FFF", 1, StatusDeCadastro.Normal, "lu", "teste123");

            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login deve ter no mínimo 3 caracteres.");
        }

        [Test]
        public void ShouldInvalidateAlterarUsuarioCommandWhenPasswordGreaterThan8()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(1, "teste", "FFF", 1, StatusDeCadastro.Normal, "luism", "teste123456");

            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Senha não pode ser maior que 8 caracteres.");
        }

        [Test]
        public void ShouldInvalidateAlterarUsuarioCommandWhenPasswordIsLessThan3()
        {
            var alterarUsuarioCommand = new AlterarUsuarioCommand(1, "teste", "FFF", 1, StatusDeCadastro.Normal, "luism", "df");

            alterarUsuarioCommand.Validate();

            var result = alterarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Senha deve ter no mínimo 3 caracteres.");
        }
    }
}
