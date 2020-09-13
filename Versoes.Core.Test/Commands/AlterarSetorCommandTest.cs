using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.Commands;
using Versoes.Entities;

namespace Versoes.Core.Test.Commands
{
    public class AlterarSetorCommandTest
    {
        [Test]
        public void ShouldInvalidateAlterarProjetoCommandWhenIdIsZero()
        {
            var _alterarSetorCommand = new AlterarSetorCommand(0, "teste", StatusDeCadastro.Normal);

            _alterarSetorCommand.Validate();

            var result = _alterarSetorCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Id do setor inválido");
        }

        [Test]
        public void ShouldInvalidateAlterarProjetoCommandWhenNameIsEmpty()
        {
            var _alterarSetorCommand = new AlterarSetorCommand(1, "", StatusDeCadastro.Normal);

            _alterarSetorCommand.Validate();

            var result = _alterarSetorCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome é obrigatório");
        }

        [Test]
        public void ShouldInvalidateAlterarProjetoCommandWhenNameIsGreaterThan30()
        {
            var _alterarSetorCommand = new AlterarSetorCommand(1, "dhasghghghaghdgashdghgdhjghasgdjhagddhasghgh", StatusDeCadastro.Normal);

            _alterarSetorCommand.Validate();

            var result = _alterarSetorCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome não pode ser maior que 30 caracteres.");
        }

        [Test]
        public void ShouldInvalidateAlterarProjetoCommandWhenNameIsLessThan3()
        {
            var _alterarSetorCommand = new AlterarSetorCommand(1, "as", StatusDeCadastro.Normal);

            _alterarSetorCommand.Validate();

            var result = _alterarSetorCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome deve ter no mínimo 3 caracteres.");
        }
    }
}
