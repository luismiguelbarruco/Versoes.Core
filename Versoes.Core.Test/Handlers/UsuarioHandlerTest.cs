using AutoMapper;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.Handlers;
using Versoes.Core.Domain.Repositories;
using Versoes.Core.Domain.Services;
using Versoes.Core.Domain.ValueObjects;
using Versoes.Entities.Models;

namespace Versoes.Core.Test.Handlers
{
    [TestFixture(TestName = "UsuarioHandler")]
    public class UsuarioHandlerTest
    {
        private UsuarioHandler _usuarioHandler;
        private Mock<IRepositoryWrapper> _repositoryMock;
        private Mock<IMapper> _mapperMock;
        private Mock<ICryptographyService> _cryptographyServiceMock;

        [SetUp]
        public void Setup()
        {
            _mapperMock = new Mock<IMapper>();
            _repositoryMock = new Mock<IRepositoryWrapper>();
            _cryptographyServiceMock = new Mock<ICryptographyService>();
            _usuarioHandler = new UsuarioHandler(_mapperMock.Object, _repositoryMock.Object, _cryptographyServiceMock.Object);
        }

        [Test]
        public async Task ShouldInvalidateCadastrarUsuarioCommandWhenAlreadyUsuarioWithSameName()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Teste", 
                Sigla = "FFF",
                Status = StatusDeCadastro.Normal,
                SetorId = 1,
                Login = "teste",
                Senha = "teste"
            };

            _repositoryMock.Setup(r => r.Usuario.GetUsuarioByNomeAsync("Teste")).Returns(Task.FromResult(usuario));

            var command = new CadastrarUsuarioCommand(
                usuario.Nome,
                usuario.Sigla,
                usuario.SetorId,
                usuario.Status,
                usuario.Login,
                usuario.Senha
            );

            var result = await _usuarioHandler.Handler(command);

            Assert.AreEqual("Já existe um usuário com mesmo nome cadastrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateCadastrarUsuarioCommandWhenAlreadyUsuarioWithSameLogin()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Teste", 
                Sigla = "FFF",
                Status = StatusDeCadastro.Normal,
                SetorId = 1,
                Login = "teste",
                Senha = "teste"
            };

            _repositoryMock.Setup(r => r.Usuario.GetUsuarioByNomeAsync("Teste"));
            _repositoryMock.Setup(r => r.Usuario.GetUsuarioByLoginAsync("teste")).Returns(Task.FromResult(usuario));

            var command = new CadastrarUsuarioCommand(
                usuario.Nome,
                usuario.Sigla,
                usuario.SetorId,
                usuario.Status,
                usuario.Login,
                usuario.Senha
            );

            var result = await _usuarioHandler.Handler(command);

            Assert.AreEqual("Login já cadastrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateCadastrarUsuarioCommandWhenAlreadyUsuarioWithSameSigla()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Teste", 
                Sigla = "FFF",
                Status = StatusDeCadastro.Normal,
                SetorId = 1,
                Login = "teste",
                Senha = "teste"
            };

            _repositoryMock.Setup(r => r.Usuario.GetUsuarioByNomeAsync("Teste"));
            _repositoryMock.Setup(r => r.Usuario.GetUsuarioBySiglaAsync("FFF")).Returns(Task.FromResult(usuario));

            var command = new CadastrarUsuarioCommand(
                usuario.Nome,
                usuario.Sigla,
                usuario.SetorId,
                usuario.Status,
                usuario.Login,
                usuario.Senha
            );

            var result = await _usuarioHandler.Handler(command);

            Assert.AreEqual("Já existe um usuário com a mesma sigla cadastrada", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateCadastrarUsuarioCommandWhenNotFoundSetorById()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Teste", 
                Sigla = "FFF",
                Status = StatusDeCadastro.Normal,
                SetorId = 1,
                Login = "teste",
                Senha = "teste"
            };

            _repositoryMock.Setup(r => r.Usuario.GetUsuarioByNomeAsync("Teste"));
            _repositoryMock.Setup(r => r.Usuario.GetUsuarioBySiglaAsync("FFF"));
            _repositoryMock.Setup(r => r.Usuario.GetUsuarioByLoginAsync("teste"));
            _repositoryMock.Setup(r => r.Setor.GetSetorByIdAsync(1));

            var command = new CadastrarUsuarioCommand(
                usuario.Nome,
                usuario.Sigla,
                usuario.SetorId,
                usuario.Status,
                usuario.Login,
                usuario.Senha
            );

            var result = await _usuarioHandler.Handler(command);

            Assert.AreEqual("Setor não encontrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateCadastrarUsuarioCommandValid()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Teste", 
                Sigla = "FFF",
                Status = StatusDeCadastro.Normal,
                SetorId = 1,
                Login = "teste",
                Senha = "teste"
            };

            var setor = new Setor
            {
                Id = 1,
                Nome = "Teste"
            };

            var command = new CadastrarUsuarioCommand(
                usuario.Nome,
                usuario.Sigla,
                usuario.SetorId,
                usuario.Status,
                usuario.Login,
                usuario.Senha
            );

            _mapperMock.Setup(m => m.Map<Usuario>(command)).Returns(usuario);

            _cryptographyServiceMock.Setup(c => c.Encrypt(usuario.Senha)).Returns("senha");

            _repositoryMock.Setup(r => r.Usuario.Create(usuario));
            _repositoryMock.Setup(r => r.Setor.GetSetorByIdAsync(1)).Returns(Task.FromResult(setor));
            _repositoryMock.Setup(r => r.SaveAsync());

            

            var result = await _usuarioHandler.Handler(command);

            Assert.AreEqual("Usuário cadastrado com sucesso!", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateAlterarProjetoCommandWhenNotFoundSetorById()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Teste", 
                Sigla = "FFF",
                Status = StatusDeCadastro.Normal,
                SetorId = 1,
                Login = "teste",
                Senha = "teste"
            };

            _repositoryMock.Setup(r => r.Usuario.GetUsuarioByIdAsync(1));

            var command = new AlterarUsuarioCommand(
                usuario.Id,
                usuario.Nome,
                usuario.Sigla,
                usuario.SetorId,
                usuario.Status,
                usuario.Login,
                usuario.Senha               
            );

            var result = await _usuarioHandler.Handler(command);

            Assert.AreEqual("Usuário não encontrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateAlterarProjetoCommandWhenAlreadyUsuarioWithSameName()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Teste", 
                Sigla = "FFF",
                Status = StatusDeCadastro.Normal,
                SetorId = 1,
                Login = "teste",
                Senha = "teste"
            };

            var usuarioJaCadastrado = new Usuario
            {
                Nome = "Teste", 
                Sigla = "FFF",
                Status = StatusDeCadastro.Normal,
                SetorId = 1,
                Login = "teste",
                Senha = "teste"
            };

            _repositoryMock.Setup(r => r.Usuario.GetUsuarioByIdAsync(1)).Returns(Task.FromResult(usuario));
            _repositoryMock.Setup(r => r.Usuario.GetSetorByNameAndDiferentIdAsync(1, "Teste")).Returns(Task.FromResult(usuarioJaCadastrado));

            var command = new AlterarUsuarioCommand(
                usuario.Id,
                usuario.Nome,
                usuario.Sigla,
                usuario.SetorId,
                usuario.Status,
                usuario.Login,
                usuario.Senha               
            );

            var result = await _usuarioHandler.Handler(command);

            Assert.AreEqual("Já existe um usuário com mesmo nome cadastrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateAlterarUsuarioCommandWhenAlreadyUsuarioWithSameLogin()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Teste", 
                Sigla = "FFF",
                Status = StatusDeCadastro.Normal,
                SetorId = 1,
                Login = "teste",
                Senha = "teste"
            };

            _repositoryMock.Setup(r => r.Usuario.GetUsuarioByIdAsync(usuario.Id)).Returns(Task.FromResult(usuario));
            _repositoryMock.Setup(r => r.Usuario.GetSetorByLoginAndDiferentIdAsync(1, "teste")).Returns(Task.FromResult(usuario));

            var command = new AlterarUsuarioCommand(
                usuario.Id,
                usuario.Nome,
                usuario.Sigla,
                usuario.SetorId,
                usuario.Status,
                usuario.Login,
                usuario.Senha
            );

            var result = await _usuarioHandler.Handler(command);

            Assert.AreEqual("Já existe um usuário com mesmo login cadastrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateAlterarUsuarioCommandWhenAlreadyUsuarioWithSameSigla()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Teste", 
                Sigla = "FFF",
                Status = StatusDeCadastro.Normal,
                SetorId = 1,
                Login = "teste",
                Senha = "teste"
            };

            _repositoryMock.Setup(r => r.Usuario.GetUsuarioByIdAsync(1)).Returns(Task.FromResult(usuario));
            _repositoryMock.Setup(r => r.Usuario.GetUsuarioBySiglaAndDiferentIdAsync(1, "FFF")).Returns(Task.FromResult(usuario));

            var command = new AlterarUsuarioCommand(
                usuario.Id,
                usuario.Nome,
                usuario.Sigla,
                usuario.SetorId,
                usuario.Status,
                usuario.Login,
                usuario.Senha
            );

            var result = await _usuarioHandler.Handler(command);

            Assert.AreEqual("Já existe um usuário com a mesma sigla cadastrada", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldInvalidateAlterarUsuarioCommandWhenNotFoundSetorById()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Teste", 
                Sigla = "FFF",
                Status = StatusDeCadastro.Normal,
                SetorId = 1,
                Login = "teste",
                Senha = "teste"
            };

            var setor = new Setor
            {
                Id = 1,
                Nome = "Teste"
            };

            _repositoryMock.Setup(r => r.Usuario.GetUsuarioByIdAsync(1)).Returns(Task.FromResult(usuario));
            _repositoryMock.Setup(r => r.Setor.GetSetorByIdAsync(1));

            var command = new AlterarUsuarioCommand(
                usuario.Id,
                usuario.Nome,
                usuario.Sigla,
                usuario.SetorId,
                usuario.Status,
                usuario.Login,
                usuario.Senha
            );

            var result = await _usuarioHandler.Handler(command);

            Assert.AreEqual("Setor não encontrado", ((CommandResult)result).Message);
        }

        [Test]
        public async Task ShouldUpdateProjectWithAlterarUsuarioCommandValid()
        {
            var usuario = new Usuario
            {
                Id = 1,
                Nome = "Teste", 
                Sigla = "FFF",
                Status = StatusDeCadastro.Normal,
                SetorId = 1,
                Login = "teste",
                Senha = "teste"
            };

            var command = new AlterarUsuarioCommand(
                usuario.Id,
                usuario.Nome,
                usuario.Sigla,
                usuario.SetorId,
                usuario.Status,
                usuario.Login,
                usuario.Senha               
            );

            var setor = new Setor
            {
                Id = 1,
                Nome = "Teste"
            };

            _mapperMock.Setup(m => m.Map<Usuario>(command)).Returns(usuario);

            _cryptographyServiceMock.Setup(c => c.Encrypt(usuario.Senha)).Returns("senha");

            _repositoryMock.Setup(r => r.Usuario.GetUsuarioByIdAsync(1)).Returns(Task.FromResult(usuario));
            _repositoryMock.Setup(r => r.Setor.GetSetorByIdAsync(1)).Returns(Task.FromResult(setor));
            _repositoryMock.Setup(r => r.Usuario.Update(usuario));
            _repositoryMock.Setup(r => r.SaveAsync());

            var result = await _usuarioHandler.Handler(command);

            Assert.AreEqual("Dados alterados com sucesso!", ((CommandResult)result).Message);
        }
    }
}