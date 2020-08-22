using AutoMapper;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.Handlers;
using Versoes.Core.Domain.Repositories;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Domain.Services
{
    public class ProjetoService : Notifiable, IProjetoService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public ProjetoService(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IEnumerable<ProjetoViewModel>> GetAllProjetosAsync()
        {
            var projetos = await _repository.Projeto.GetAllProjetosAsync();

            var projetosResult = _mapper.Map<IEnumerable<ProjetoViewModel>>(projetos);

            return projetosResult;
        }

        public async Task<ProjetoViewModel> GetAllProjetoByIdAsync(long id)
        {
            var projeto = await _repository.Projeto.GetProjetoByIdAsync(id);

            var projetoResult = _mapper.Map<ProjetoViewModel>(projeto);

            return projetoResult;
        }

        public async Task<IResult> InserirAsync(ProjetoForCreationViewModel projetoForCreationViewModel)
        {
            var cadastrarProjetoCommand = _mapper.Map<CadastrarProjetoCommand>(projetoForCreationViewModel);

            var projetoHandler = new ProjetoHandler(_mapper, _repository);

            var result = await projetoHandler.Handler(cadastrarProjetoCommand);

            return result;
        }

        public async Task<IResult> AtualizarAsync(ProjetoForUpdateViewModel projetoForUpdateVireModel)
        {
            var alterarProjetoCommand = _mapper.Map<AlterarProjetoCommand>(projetoForUpdateVireModel);

            var projetoHandler = new ProjetoHandler(_mapper, _repository);

            var result = await projetoHandler.Handler(alterarProjetoCommand);

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}