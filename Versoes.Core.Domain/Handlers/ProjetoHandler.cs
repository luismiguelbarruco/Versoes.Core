using AutoMapper;
using Flunt.Notifications;
using System.Threading.Tasks;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.Repositories;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Handlers
{
    public class ProjetoHandler : Notifiable, IHandle<CadastrarProjetoCommand>, IHandle<AlterarProjetoCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public ProjetoHandler(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResult> Handler(CadastrarProjetoCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return command.ValidationResult;

            var setor = await _repository.Projeto.GetProjetoByNameAsync(command.Nome);

            if (setor != null)
                return new CommandResult(false, "Já existe um projeto com mesmo nome cadastrado", command.Notifications);

            var projetoEntity = _mapper.Map<Projeto>(command);

            _repository.Projeto.Create(projetoEntity);

            await _repository.SaveAsync();

            return new CommandResult("Projeto cadastrado com sucesso!");
        }

        public async Task<IResult> Handler(AlterarProjetoCommand command)
        {
            command.Validate();

            if (!command.Valid)
                return command.ValidationResult;

            var projeto = await _repository.Projeto.GetProjetoByIdAsync(command.Id);

            if (projeto == null)
                return new CommandResult(false, "Projeto não encontrado", command.Notifications);

            projeto = await _repository.Projeto.GetProjetoByNameAndDiferentIdAsync(command.Nome, command.Id);

            if (projeto != null)
                return new CommandResult(false, "Já existe um projeto com mesmo nome cadastrado", command.Notifications);

            var projetoEntity = _mapper.Map<Projeto>(command);

            _repository.Projeto.Update(projetoEntity);

            await _repository.SaveAsync();

            return new CommandResult("Dados alterados com sucesso!");
        }
    }
}
