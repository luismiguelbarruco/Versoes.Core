using AutoMapper;
using Flunt.Notifications;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.ViewModels;
using Versoes.Core.Domain.Handlers;
using Versoes.Core.Domain.Repositories;
using System.Threading.Tasks;
using Versoes.Core.Domain.ResultComunication;
using System;
using System.Collections.Generic;

namespace Versoes.Core.Domain.Services
{
    public class SetorSerive : Notifiable, ISetorSerive
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public SetorSerive(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<SetorViewModel>> GetAllSetoresAsync()
        {
            var setores = await _repository.Setor.GetAllSetoresAsync();

            var setoresResult = _mapper .Map<IEnumerable<SetorViewModel>>(setores);

            return setoresResult;
        }

        public async Task<SetorViewModel> GetSetorByIdAsync(long id)
        {
            var setor = await _repository.Setor.GetSetorByIdAsync(id);

            var setorResult = _mapper.Map<SetorViewModel>(setor);

            return setorResult;
        }

        public async Task<IResult> InserirAsync(SetorForCreationViewModel setorForCreationViewModel)
        {
            var cadastrarSetorCommand = _mapper.Map<CadastrarSetorCommand>(setorForCreationViewModel);

            var setorHandle = new SetorHandler(_mapper, _repository);

            var result = await setorHandle.Handler(cadastrarSetorCommand);

            return result;
        }

        public async Task<IResult> AtualizarAsync(SetorForUpdateViewModel setorForUpdateViewModel)
        {
            var alterarSetorCommand = _mapper.Map<AlterarSetorCommand>(setorForUpdateViewModel);

            var setorHandle = new SetorHandler(_mapper, _repository);

            var result = await setorHandle.Handler(alterarSetorCommand);

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}