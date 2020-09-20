using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.Handlers;
using Versoes.Core.Domain.Repositories;
using Versoes.Core.Domain.ValueObjects;
using Versoes.Entities.Models;

namespace Versoes.Core.Test.Handlers
{
    [TestFixture(TestName = "SetorHandler")]
    public class SetorHandlerTest
    {
        private SetorHandler _setorHandle;
        private Mock<IRepositoryWrapper> _repositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IRepositoryWrapper>();
            _setorHandle = new SetorHandler(_mapperMock.Object, _repositoryMock.Object);
        }

        [Test]
        public async Task ShouldInvalidateCadastrarSetorCommandWhenAlreadySetortWithSameName()
        {
            var setor = new Setor
            {
                Id = 1,
                Nome = "Teste", 
                Status = StatusDeCadastro.Normal 
            };

            _repositoryMock.Setup(r => r.Setor.GetSetorByNameAsync("Teste")).Returns(Task.FromResult(setor));

            var command = new CadastrarSetorCommand("Teste", StatusDeCadastro.Normal);

            var result = await _setorHandle.Handler(command);

            Assert.AreEqual("Já existe um setor com mesmo nome cadastrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateCadastrarSetorCommandValid()
        {
            var setor = new Setor
            {
                Id = 1,
                Nome = "Teste",
                Status = StatusDeCadastro.Normal
            };

            _repositoryMock.Setup(r => r.Setor.Create(setor));
            _repositoryMock.Setup(r => r.SaveAsync());

            var command = new CadastrarSetorCommand("Teste", StatusDeCadastro.Normal);

            var result = await _setorHandle.Handler(command);

            Assert.AreEqual("Setor cadastrado com sucesso!", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateCadastrarSetorCommandWhenNotFoundSetorById()
        {
            _repositoryMock.Setup(r => r.Setor.GetSetorByIdAsync(1));

            var command = new AlterarSetorCommand(1, "Teste", StatusDeCadastro.Normal);

            var result = await _setorHandle.Handler(command);

            Assert.AreEqual("Setor não encontrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateAlterarSetorCommandWhenAlreadySetorWithSameName()
        {
            var setor = new Setor
            {
                Id = 1,
                Nome = "Teste",
                Status = StatusDeCadastro.Normal
            };

            var setorJaCadastrado = new Setor
            {
                Id = 2,
                Nome = "Teste",
                Status = StatusDeCadastro.Normal
            };

            _repositoryMock.Setup(r => r.Setor.GetSetorByIdAsync(1)).Returns(Task.FromResult(setor));
            _repositoryMock.Setup(r => r.Setor.GetSetorByNameAndDiferentIdAsync("Teste", 1)).Returns(Task.FromResult(setorJaCadastrado));

            var command = new AlterarSetorCommand(1, "Teste", StatusDeCadastro.Normal);

            var result = await _setorHandle.Handler(command);

            Assert.AreEqual("Já existe um setor com mesmo nome cadastrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateAlterarSetorCommandValid()
        {
            var setor = new Setor
            {
                Id = 1,
                Nome = "Teste",
                Status = StatusDeCadastro.Normal
            };

            _repositoryMock.Setup(r => r.Setor.GetSetorByIdAsync(1)).Returns(Task.FromResult(setor));
            _repositoryMock.Setup(r => r.Setor.Update(setor));
            _repositoryMock.Setup(r => r.SaveAsync());

            var command = new AlterarSetorCommand(1, "Teste", StatusDeCadastro.Normal);

            var result = await _setorHandle.Handler(command);

            Assert.AreEqual("Dados alterados com sucesso!", ((CommandResult)result).Message);
        }
    }
}