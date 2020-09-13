using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.Commands;
using Versoes.Entities;

namespace Versoes.Core.Test.Commands
{
    public class CadastrarProjetoCommandTest
    {
        [Test]
        public void ShouldInvalidateCadastrarProjetoCommandWhenNameIsEmpty()
        {
            var _cadastrarProjetoCommand = new CadastrarProjetoCommand("", StatusDeCadastro.Normal);

            _cadastrarProjetoCommand.Validate();

            var result = _cadastrarProjetoCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome é obrigatório");
        }

        [Test]
        public void ShouldInvalidateCadastrarProjetoCommandWhenNameIsGreaterThan60()
        {
            var _cadastrarProjetoCommand = new CadastrarProjetoCommand("dhasghghghaghdgashdghgdhjghasgdjhagddhasghghghaghdgashdghgdhjghasgdjhagd", StatusDeCadastro.Normal);

            _cadastrarProjetoCommand.Validate();

            var result = _cadastrarProjetoCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome não pode ser maior que 60 caracteres.");
        }

        [Test]
        public void ShouldInvalidateCadastrarProjetoCommandWhenNameIsLessThan3()
        {
            var _cadastrarProjetoCommand = new CadastrarProjetoCommand("as", StatusDeCadastro.Normal);

            _cadastrarProjetoCommand.Validate();

            var result = _cadastrarProjetoCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome deve ter no mínimo 3 caracteres.");
        }
    }
}
