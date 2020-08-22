using AutoMapper;
using Flunt.Notifications;
using System;
using System.Threading.Tasks;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.Commands.Validations;
using Versoes.Core.Domain.Handlers;
using Versoes.Core.Domain.Repositories;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Domain.Services
{
    public class UsuarioService : Notifiable, IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public UsuarioService(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<IResult> InserirAsync(UsuarioForCreationViewModel usuarioForCreationViewModel)
        {
            var cadastrarUsuarioCommand = _mapper.Map<CadastrarUsuarioCommand>(usuarioForCreationViewModel);

            var usuarioHandle = new UsuarioHandle(_mapper, _repository);

            var result = await usuarioHandle.Handler(cadastrarUsuarioCommand);

            return result;
        }

        public async Task<IResult> AtualizarAsync(UsuarioForUpdateViewModel usuarioForUpdateVireModel)
        {
            var alterarUsuarioCommand = _mapper.Map<AlterarUsuarioCommand>(usuarioForUpdateVireModel);

            var usuarioHandle = new UsuarioHandle(_mapper, _repository);

            var result = await usuarioHandle.Handler(alterarUsuarioCommand);

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}