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
    [TestFixture(TestName = "ProjetoHandler")]
    public class ProjetoHandlerTest
    {
        private ProjetoHandler _projetoHandler;
        private Mock<IRepositoryWrapper> _repositoryMock;
        private Mock<IMapper> _mapperMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IRepositoryWrapper>();
            _projetoHandler = new ProjetoHandler(_mapperMock.Object, _repositoryMock.Object);
        }

        [Test]
        public async Task ShouldInvalidateCadastrarProjetoCommandWhenAlreadyProjectWithSameName()
        {
            var projeto = new Projeto
            {
                Id = 1,
                Nome = "Teste", 
                Status = StatusDeCadastro.Normal 
            };

            _repositoryMock.Setup(r => r.Projeto.GetProjetoByNameAsync("Teste")).Returns(Task.FromResult(projeto));

            var command = new CadastrarProjetoCommand("Teste", StatusDeCadastro.Normal);

            var result = await _projetoHandler.Handler(command);

            Assert.AreEqual("Já existe um projeto com mesmo nome cadastrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldSaveProjectWithCadastrarProjetoCommandValid()
        {
            var projeto = new Projeto
            {
                Id = 1,
                Nome = "Teste",
                Status = StatusDeCadastro.Normal
            };

            _repositoryMock.Setup(r => r.Projeto.Create(projeto));
            _repositoryMock.Setup(r => r.SaveAsync());

            var command = new CadastrarProjetoCommand("Teste", StatusDeCadastro.Normal);

            var result = await _projetoHandler.Handler(command);

            Assert.AreEqual("Projeto cadastrado com sucesso!", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateAlterarProjetoCommandWhenNotFoundProjectById()
        {
            _repositoryMock.Setup(r => r.Projeto.GetProjetoByIdAsync(1));

            var command = new AlterarProjetoCommand(1, "Teste", StatusDeCadastro.Normal);

            var result = await _projetoHandler.Handler(command);

            Assert.AreEqual("Projeto não encontrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateAlterarProjetoCommandWhenAlreadyProjectWithSameName()
        {
            var projeto = new Projeto
            {
                Id = 1,
                Nome = "Teste",
                Status = StatusDeCadastro.Normal
            };

            var projetoJaCadastrado = new Projeto
            {
                Id = 2,
                Nome = "Teste",
                Status = StatusDeCadastro.Normal
            };

            _repositoryMock.Setup(r => r.Projeto.GetProjetoByIdAsync(1)).Returns(Task.FromResult(projeto));
            _repositoryMock.Setup(r => r.Projeto.GetProjetoByNameAndDiferentIdAsync("Teste", 1)).Returns(Task.FromResult(projetoJaCadastrado));

            var command = new AlterarProjetoCommand(1, "Teste", StatusDeCadastro.Normal);

            var result = await _projetoHandler.Handler(command);

            Assert.AreEqual("Já existe um projeto com mesmo nome cadastrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldUpdateProjectWithAlterarProjetoCommandValid()
        {
            var projeto = new Projeto
            {
                Id = 1,
                Nome = "Teste",
                Status = StatusDeCadastro.Normal
            };

            _repositoryMock.Setup(r => r.Projeto.GetProjetoByIdAsync(1)).Returns(Task.FromResult(projeto));
            _repositoryMock.Setup(r => r.Projeto.Update(projeto));
            _repositoryMock.Setup(r => r.SaveAsync());

            var command = new AlterarProjetoCommand(1, "Teste", StatusDeCadastro.Normal);

            var result = await _projetoHandler.Handler(command);

            Assert.AreEqual("Dados alterados com sucesso!", ((CommandResult)result).Message);
        }
    }
}