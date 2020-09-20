using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Test.ValidationsTest
{
    [TestFixture(TestName = "CadastrarSetorValidation")]
    public class CadastrarSetorValidationTest
    {
        private SetorForCreationViewModel _setorForCreationViewModel;

        [SetUp]
        public void Setup()
        {
            _setorForCreationViewModel = new SetorForCreationViewModel
            {
                Nome = "Test"
            };
        }

        [Test]
        public void ShouldInvalidateSetorForCreationViewModelWhenNameIsEmpty()
        {
            _setorForCreationViewModel.Nome = string.Empty;

            _setorForCreationViewModel.Validate();

            var result = _setorForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome é obrigatório");
        }

        [Test]
        public void ShouldInvalidateSetorForCreationViewModelWhenNameIsGreaterThan30()
        {
            _setorForCreationViewModel.Nome = "dhasghghghaghdgashdghgdhjghasgdjhagd";

            _setorForCreationViewModel.Validate();

            var result = _setorForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome não pode ser maior que 30 caracteres.");
        }

        [Test]
        public void ShouldInvalidateSetorForCreationViewModelWhenNameIsLessThan3()
        {
            _setorForCreationViewModel.Nome = "1";

            _setorForCreationViewModel.Validate();

            var result = _setorForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome deve ter no mínimo 3 caracteres.");
        }
    }
}
