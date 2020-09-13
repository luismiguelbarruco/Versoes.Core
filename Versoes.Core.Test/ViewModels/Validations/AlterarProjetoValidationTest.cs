using NUnit.Framework;
using System.Linq;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Test.ValidationsTest
{
    [TestFixture]
    public class AlterarProjetoValidationTest
    {
        private ProjetoForUpdateViewModel _projetoForUpdateViewModel;

        [SetUp]
        public void Setup()
        {
            _projetoForUpdateViewModel = new ProjetoForUpdateViewModel
            {
                Id = 1,
                Nome = "Test"
            };
        }

        [Test]
        public void ShouldInvalidateProjetoForUpdateViewModelWhenIdIsZero()
        {
            _projetoForUpdateViewModel.Id = 0;

            _projetoForUpdateViewModel.Validate();

            var result = _projetoForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Id do projeto inválido");
        }

        [Test]
        public void ShouldInvalidateProjetoForUpdateViewModelWhenNameIsEmpty()
        {
            _projetoForUpdateViewModel.Nome = string.Empty;

            _projetoForUpdateViewModel.Validate();

            var result = _projetoForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome é obrigatório");
        }

        [Test]
        public void ShouldInvalidateProjetoForUpdateViewModelWhenNameIsGreaterThan60()
        {
            _projetoForUpdateViewModel.Nome = "dhasghghghaghdgashdghgdhjghasgdjhagddhasghghghaghdgashdghgdhjghasgdjhagd";

            _projetoForUpdateViewModel.Validate();

            var result = _projetoForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome não pode ser maior que 60 caracteres.");
        }

        [Test]
        public void ShouldInvalidateProjetoForUpdateViewModelWhenNameIsLessThan3()
        {
            _projetoForUpdateViewModel.Nome = "1";

            _projetoForUpdateViewModel.Validate();

            var result = _projetoForUpdateViewModel.Notifications.ToList();

            Assert.AreEqual(result[0].Message, "Nome deve ter no mínimo 3 caracteres.");
        }
    }
}
