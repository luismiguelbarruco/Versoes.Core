using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.ValueObjects;

namespace Versoes.Core.Test.Commands
{
    [TestFixture(TestName = "AlterarProjetoCommand")]
    public class AlterarProjetoCommandTest
    {
        [Test]
        public void ShouldInvalidateAlterarProjetoCommandWhenIdIsZero()
        {
            var _alterarProjetoCommand = new AlterarProjetoCommand(0, "teste", StatusDeCadastro.Normal);

            _alterarProjetoCommand.Validate();

            var result = _alterarProjetoCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Id do projeto inválido");
        }

        [Test]
        public void ShouldInvalidateAlterarProjetoCommandWhenNameIsEmpty()
        {
            var _alterarProjetoCommand = new AlterarProjetoCommand(1, "", StatusDeCadastro.Normal);

            _alterarProjetoCommand.Validate();

            var result = _alterarProjetoCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome é obrigatório");
        }

        [Test]
        public void ShouldInvalidateAlterarProjetoCommandWhenNameIsGreaterThan60()
        {
            var _alterarProjetoCommand = new AlterarProjetoCommand(1, "dhasghghghaghdgashdghgdhjghasgdjhagddhasghghghaghdgashdghgdhjghasgdjhagd", StatusDeCadastro.Normal);

            _alterarProjetoCommand.Validate();

            var result = _alterarProjetoCommand.Notifications.ToList();
            
            Assert.AreEqual(result[0].Message, "Nome não pode ser maior que 60 caracteres.");
        }

        [Test]
        public void ShouldInvalidateAlterarProjetoCommandWhenNameIsLessThan3()
        {
            var _alterarProjetoCommand = new AlterarProjetoCommand(1, "as", StatusDeCadastro.Normal);

            _alterarProjetoCommand.Validate();

            var result = _alterarProjetoCommand.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome deve ter no mínimo 3 caracteres.");
        }
    }
}
