using AutoMapper;
using System.Threading.Tasks;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.Commands.Validations;
using Versoes.Core.Domain.Repositories;
using Versoes.Core.Domain.ResultComunication;

namespace Versoes.Core.Domain.Handlers
{
    public class UsuarioHandle : IHandle<CadastrarUsuarioCommand>, IHandle<AlterarUsuarioCommand>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;

        public UsuarioHandle(IMapper mapper, IRepositoryWrapper repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public Task<IResult> Handler(CadastrarUsuarioCommand command)
        {
            throw new System.NotImplementedException();
        }

        public Task<IResult> Handler(AlterarUsuarioCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
