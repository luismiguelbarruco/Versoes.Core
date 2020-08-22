using AutoMapper;
using Versoes.Core.Domain.Commands;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.AutoMapper
{
    public class CommandToModel : Profile
    {
        public CommandToModel()
        {
            CreateMap<CadastrarProjetoCommand, Projeto>();
            CreateMap<AlterarProjetoCommand, Projeto>();
            CreateMap<CadastrarSetorCommand, Setor>();
            CreateMap<AlterarSetorCommand, Setor>();
        }
    }
}
