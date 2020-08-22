using AutoMapper;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Domain.AutoMapper
{
    public class ViewModelToCommand : Profile
    {
        public ViewModelToCommand()
        {
            CreateMap<ProjetoForCreationViewModel, CadastrarProjetoCommand>()
                .ConstructUsing(p => new CadastrarProjetoCommand(p.Nome, p.Status))
                .ForMember(p => p.ValidationResult, opt => opt.Ignore());

            CreateMap<ProjetoForUpdateVireModel, AlterarProjetoCommand>()
                .ConstructUsing(p => new AlterarProjetoCommand(p.Id, p.Nome, p.Status))
                .ForMember(p => p.ValidationResult, opt => opt.Ignore());

            CreateMap<SetorForCreationViewModel, CadastrarSetorCommand>()
                .ConstructUsing(p => new CadastrarSetorCommand(p.Nome, p.Status))
                .ForMember(p => p.ValidationResult, opt => opt.Ignore());

            CreateMap<SetorForUpdateViewModel, AlterarSetorCommand>()
                .ConstructUsing(p => new AlterarSetorCommand(p.Id, p.Nome, p.Status))
                .ForMember(p => p.ValidationResult, opt => opt.Ignore());
        }
    }
}
