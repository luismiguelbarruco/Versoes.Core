using AutoMapper;
using System.Threading.Tasks;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.Commands.Validations;
using Versoes.Core.Domain.Repositories;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.Services;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Handlers
{
    public class UsuarioHandle : IHandle<CadastrarUsuarioCommand>, IHandle<AlterarUsuarioCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;
        private readonly ICryptography _cryptography;

        public UsuarioHandle(IMapper mapper, IRepositoryWrapper repository, ICryptography cryptography)
        {
            _mapper = mapper;
            _repository = repository;
            _cryptography = cryptography;
        }

        public async Task<IResult> Handler(CadastrarUsuarioCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return command.ValidationResult;

            var usuario = await _repository.Usuario.GetUsuarioByNomeAsync(command.Nome);

            if(usuario != null)
                return new CommandResult(false, "Já existe um usuário com mesmo nome cadastrado", command.Notifications);

            usuario = await _repository.Usuario.GetUsuarioByLoginAsync(command.Login);

            if (usuario != null)
                return new CommandResult(false, "Login já cadastrado", command.Notifications);

            usuario = await _repository.Usuario.GetUsuarioBySiglaAsync(command.Sigla);

            if (usuario != null)
                return new CommandResult(false, "Já existe um usuário com a mesma sigla cadastrada", command.Notifications);

            var setor = await _repository.Setor.GetSetorByIdAsync(command.SetorId);

            if (setor == null)
                return new CommandResult(false, "Setor não encontrado", command.Notifications);

            var usuarioEntity = _mapper.Map<Usuario>(command);

            var passwordEncrypted = _cryptography.Encrypt(usuarioEntity.Senha);

            usuarioEntity.Senha = passwordEncrypted;

            _repository.Usuario.Create(usuarioEntity);

            await _repository.SaveAsync();

            return new CommandResult("Usuário cadastrado com sucesso!");
        }

        public async Task<IResult> Handler(AlterarUsuarioCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return command.ValidationResult;

            var usuario = await _repository.Usuario.GetUsuarioByIdAsync(command.Id);

            if (usuario == null)
                return new CommandResult(false, "Usuário não encontrado", command.Notifications);

            usuario = await _repository.Usuario.GetSetorByNameAndDiferentIdAsync(command.Id, command.Nome);

            if (usuario != null)
                return new CommandResult(false, "Já existe um usuário com mesmo nome cadastrado", command.Notifications);

            usuario = await _repository.Usuario.GetSetorByLoginAndDiferentIdAsync(command.Id, command.Login);

            if (usuario != null)
                return new CommandResult(false, "Já existe um usuário com mesmo login cadastrado", command.Notifications);

            usuario = await _repository.Usuario.GetSetorBySiglaAndDiferentIdAsync(command.Id, command.Sigla);

            if (usuario != null)
                return new CommandResult(false, "Já existe um usuário com a mesma sigla cadastrada", command.Notifications);

            var setor = await _repository.Setor.GetSetorByIdAsync(command.SetorId);

            if (setor == null)
                return new CommandResult(false, "Setor não encontrado", command.Notifications);

            var usuarioEntity = _mapper.Map<Usuario>(command);

            var passwordEncrypted = _cryptography.Encrypt(usuarioEntity.Senha);

            usuarioEntity.Senha = passwordEncrypted;

            _repository.Usuario.Update(usuarioEntity);

            await _repository.SaveAsync();

            return new CommandResult("Dados alterados com sucesso!");
        }
    }
}
