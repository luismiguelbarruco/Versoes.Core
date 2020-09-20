using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.ValueObjects;

namespace Versoes.Core.Test.Commands
{
    [TestFixture(TestName = "CadastrarUsuarioCommand")]
    public class CadastrarUsuarioCommandTest
    {
        [Test]
        public void ShouldInvalidateCadastrarUsuarioCommandWhenNameIsEmpty()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand(string.Empty, "FFF", 1, StatusDeCadastro.Normal, "luism", "teste123");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome é obrigatório");
        }

        [Test]
        public void ShouldInvalidateCadastrarUsuarioCommandWhenNameIsGreaterThan30()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand("dhasghghghaghdgashdghgdhjghasgdjhagddhasghg", "teste", 1, StatusDeCadastro.Normal, "luism", "teste123");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome não pode ser maior que 30 caracteres.");
        }

        [Test]
        public void ShouldInvalidateCadastrarUsuarioCommandWhenNameIsLessThan3()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand("an", "tt", 1, StatusDeCadastro.Normal, "luism", "teste123");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome deve ter no mínimo 3 caracteres.");
        }

        [Test]
        public void ShouldInvalidateUpdateUserWhenInitialsIsEmpty()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand("teste", "", 1, StatusDeCadastro.Normal, "luism", "teste123");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Sigla é obrigatório");
        }

        [Test]
        public void ShouldInvalidateCadastrarUsuarioCommandWhenInitialsIsGreaterThan5()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand("teste", "FFFFFD", 1, StatusDeCadastro.Normal, "luism", "teste123");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Sigla não pode ser maior que 5 caracteres.");
        }

        [Test]
        public void ShouldInvalidateCadastrarUsuarioCommandWhenInitialsIsLessThan2()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand("teste", "F", 1, StatusDeCadastro.Normal, "luism", "teste123");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Sigla deve ter no mínimo 2 caracteres.");
        }

        [Test]
        public void ShouldInvalidateCadastrarUsuarioCommandWhenIdDepartamentIsZero()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand("teste", "FFF", 0, StatusDeCadastro.Normal, "", "teste123");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Obrigatório informar um setor com id válido");
        }

        [Test]
        public void ShouldInvalidateCadastrarUsuarioCommandWhenLoginIsEmpty()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand("teste", "FFF", 1, StatusDeCadastro.Normal, "", "teste123");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login é obrigatório");
        }

        [Test]
        public void ShouldInvalidateCadastrarUsuarioCommandWhenLoginIsGreaterThan20()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand("teste", "FFF", 1, StatusDeCadastro.Normal, "ssluismsfsffsfsfdsfsdffd", "teste123");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login não pode ser maior que 20 caracteres.");
        }

        [Test]
        public void ShouldInvalidateCadastrarUsuarioCommandWhenLoginIsLessThan3()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand( "teste", "FFF", 1, StatusDeCadastro.Normal, "lu", "teste123");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Login deve ter no mínimo 3 caracteres.");
        }

        [Test]
        public void ShouldInvalidateCadastrarUsuarioCommandWhenPasswordIsEmpty()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand("teste", "FFF", 1, StatusDeCadastro.Normal, "luism", "");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Senha é obrigatório");
        }

        [Test]
        public void ShouldInvalidateCadastrarUsuarioCommandWhenPasswordGreaterThan8()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand("teste", "FFF", 1, StatusDeCadastro.Normal, "luism", "teste123456");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Senha não pode ser maior que 8 caracteres.");
        }

        [Test]
        public void ShouldInvalidateCadastrarUsuarioCommandWhenPasswordIsLessThan3()
        {
            var cadastrarUsuarioCommand = new CadastrarUsuarioCommand("teste", "FFF", 1, StatusDeCadastro.Normal, "luism", "df");

            cadastrarUsuarioCommand.Validate();

            var result = cadastrarUsuarioCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Senha deve ter no mínimo 3 caracteres.");
        }
    }
}
