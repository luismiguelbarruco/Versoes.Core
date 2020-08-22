using AutoMapper;
using Flunt.Notifications;
using System.Threading.Tasks;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.Repositories;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Handlers
{
    public class SetorHandler : Notifiable, IHandle<CadastrarSetorCommand>, IHandle<AlterarSetorCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public SetorHandler(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResult> Handler(CadastrarSetorCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return command.ValidationResult;

            var setor = await _repository.Setor.GetSetorByNameAsync(command.Nome);

            if(setor != null)
                return new CommandResult(false, "Já existe um setor com mesmo nome cadastrado", command.Notifications);

            var setorEntity = _mapper.Map<Setor>(command);

            _repository.Setor.Create(setorEntity);

            await _repository.SaveAsync();

            return new CommandResult("Setor cadastrado com sucesso!");
        }

        public async Task<IResult> Handler(AlterarSetorCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return command.ValidationResult;

            var setor = await _repository.Setor.GetSetorByIdAsync(command.Id);

            if(setor == null)
                return new CommandResult(false, "Setor não encontrado", command.Notifications);

            setor = await _repository.Setor.GetSetorByNameAndDiferentIdAsync(command.Nome, command.Id);

            if (setor != null)
                return new CommandResult(false, "Já existe um setor com mesmo nome cadastrado", command.Notifications);

            var setorEntity = _mapper.Map<Setor>(command);

            _repository.Setor.Update(setorEntity);

            await _repository.SaveAsync();

            return new CommandResult("Dados alterados com sucesso!");
        }
    }
}
