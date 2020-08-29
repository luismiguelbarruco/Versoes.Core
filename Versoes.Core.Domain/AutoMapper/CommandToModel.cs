using AutoMapper;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.Commands.Validations;
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

            CreateMap<CadastrarUsuarioCommand, Usuario>()
                .ForPath(u => u.Setor.Id, opt => opt.MapFrom(source => source.SetorId))
                .ForPath(u => u.Setor.Nome, opt => opt.MapFrom(source => string.Empty));

            CreateMap<AlterarUsuarioCommand, Usuario>()
                .ForPath(u => u.Setor.Id, opt => opt.MapFrom(source => source.SetorId))
                .ForPath(u => u.Setor.Nome, opt => opt.MapFrom(source => string.Empty));
        }
    }
}
