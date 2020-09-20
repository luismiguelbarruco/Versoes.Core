
using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Test.ValidationsTest
{
    [TestFixture(TestName = "AlterarSetorValidation")]
    public class AlterarSetorValidationTest
    {
        private SetorForUpdateViewModel _setorForUpdateViewModel;

        [SetUp]
        public void Setup()
        {
            _setorForUpdateViewModel = new SetorForUpdateViewModel
            {
                Id = 1,
                Nome = "Test"
            };
        }

        [Test]
        public void ShouldInvalidateSetorForUpdateViewModelWhenIdIsZero()
        {
            _setorForUpdateViewModel.Id = 0;

            _setorForUpdateViewModel.Validate();

            var result = _setorForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Id do setor inválido");
        }

        [Test]
        public void ShouldInvalidateSetorForUpdateViewModelWhenNameIsEmpty()
        {
            _setorForUpdateViewModel.Nome = string.Empty;

            _setorForUpdateViewModel.Validate();

            var result = _setorForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome é obrigatório");
        }

        [Test]
        public void ShouldInvalidateSetorForUpdateViewModelWhenNameIsGreaterThan30()
        {
            _setorForUpdateViewModel.Nome = "dhasghghghaghdgashdghgdhjghasgdjhagd";

            _setorForUpdateViewModel.Validate();

            var result = _setorForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome não pode ser maior que 30 caracteres.");
        }

        [Test]
        public void ShouldInvalidateSetorForUpdateViewModelWhenNameIsLessThan3()
        {
            _setorForUpdateViewModel.Nome = "1";

            _setorForUpdateViewModel.Validate();

            var result = _setorForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome deve ter no mínimo 3 caracteres.");
        }
    }
}
