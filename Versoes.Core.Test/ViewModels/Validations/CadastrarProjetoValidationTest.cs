using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Test.ValidationsTest
{
    public class CadastrarProjetoValidationTest
    {
        private ProjetoForCreationViewModel _projetoForCreationViewModel;

        [SetUp]
        public void Setup()
        {
            _projetoForCreationViewModel = new ProjetoForCreationViewModel
            {
                Id = 1,
                Nome = "Test"
            };
        }

        [Test]
        public void ShouldInvalidateProjetoForCreationViewModelWhenNameIsEmpty()
        {
            _projetoForCreationViewModel.Nome = string.Empty;

            _projetoForCreationViewModel.Validate();

            var result = _projetoForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome é obrigatório");
        }

        [Test]
        public void ShouldInvalidateProjetoForCreationViewModelWhenNameIsGreaterThan60()
        {
            _projetoForCreationViewModel.Nome = "dhasghghghaghdgashdghgdhjghasgdjhagddhasghghghaghdgashdghgdhjghasgdjhagd";

            _projetoForCreationViewModel.Validate();

            var result = _projetoForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome não pode ser maior que 60 caracteres.");
        }

        [Test]
        public void ShouldInvalidateProjetoForCreationViewModelWhenNameIsLessThan3()
        {
            _projetoForCreationViewModel.Nome = "1";

            _projetoForCreationViewModel.Validate();

            var result = _projetoForCreationViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome deve ter no mínimo 3 caracteres.");
        }
    }
}
