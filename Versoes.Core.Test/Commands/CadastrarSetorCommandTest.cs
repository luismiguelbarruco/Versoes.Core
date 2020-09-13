using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.Commands;
using Versoes.Entities;

namespace Versoes.Core.Test.Commands
{
    public class CadastrarSetorCommandTest
    {
        [Test]
        public void ShouldInvalidateCadastrarSetorCommandCommandWhenNameIsEmpty()
        {
            var _cadastrarSetorCommand = new CadastrarSetorCommand("", StatusDeCadastro.Normal);

            _cadastrarSetorCommand.Validate();

            var result = _cadastrarSetorCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome é obrigatório");
        }

        [Test]
        public void ShouldInvalidateCadastrarSetorCommandWhenNameIsGreaterThan30()
        {
            var _cadastrarSetorCommand = new CadastrarSetorCommand("dhasghghghaghdgashdghgdhjghasgdjhagddhasghgh", StatusDeCadastro.Normal);

            _cadastrarSetorCommand.Validate();

            var result = _cadastrarSetorCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome não pode ser maior que 30 caracteres.");
        }

        [Test]
        public void ShouldInvalidateCadastrarSetorCommandWhenNameIsLessThan3()
        {
            var _cadastrarSetorCommand = new CadastrarSetorCommand("as", StatusDeCadastro.Normal);

            _cadastrarSetorCommand.Validate();

            var result = _cadastrarSetorCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome deve ter no mínimo 3 caracteres.");
        }
    }
}
