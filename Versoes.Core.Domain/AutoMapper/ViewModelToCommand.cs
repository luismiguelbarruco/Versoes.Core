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
                .ForMember(p => p.ValidationResult, opt => opt.Ignore())
                .ForMember(p => p.Nome, opt => opt.MapFrom(v => v.Nome.Trim()));

            CreateMap<ProjetoForUpdateViewModel, AlterarProjetoCommand>()
                .ConstructUsing(p => new AlterarProjetoCommand(p.Id, p.Nome, p.Status))
                .ForMember(p => p.ValidationResult, opt => opt.Ignore())
                .ForMember(p => p.Nome, opt => opt.MapFrom(v => v.Nome.Trim()));

            CreateMap<SetorForCreationViewModel, CadastrarSetorCommand>()
                .ConstructUsing(s => new CadastrarSetorCommand(s.Nome, s.Status))
                .ForMember(s => s.ValidationResult, opt => opt.Ignore())
                .ForMember(s => s.Nome, opt => opt.MapFrom(v => v.Nome.Trim()));

            CreateMap<SetorForUpdateViewModel, AlterarSetorCommand>()
                .ConstructUsing(s => new AlterarSetorCommand(s.Id, s.Nome, s.Status))
                .ForMember(s => s.ValidationResult, opt => opt.Ignore())
                .ForMember(s => s.Nome, opt => opt.MapFrom(v => v.Nome.Trim()));

            CreateMap<UsuarioForCreationViewModel, CadastrarUsuarioCommand>()
                .ConstructUsing(u => new CadastrarUsuarioCommand(u.Nome, u.Sigla, u.Setor.Id, u.Status, u.Login, u.Senha))
                .ForMember(u => u.ValidationResult, opt => opt.Ignore())
                .ForMember(u => u.Nome, opt => opt.MapFrom(v => v.Nome.Trim()))
                .ForMember(u => u.Sigla, opt => opt.MapFrom(v => v.Sigla.Trim()))
                .ForMember(u => u.Login, opt => opt.MapFrom(v => v.Login.Trim()));

            CreateMap<UsuarioForUpdateViewModel, AlterarUsuarioCommand>()
                .ConstructUsing(u => new AlterarUsuarioCommand(u.Id, u.Nome, u.Sigla, u.Setor.Id, u.Status, u.Login, u.Senha))
                .ForMember(u => u.ValidationResult, opt => opt.Ignore())
                .ForMember(u => u.Nome, opt => opt.MapFrom(v => v.Nome.Trim()))
                .ForMember(u => u.Sigla, opt => opt.MapFrom(v => v.Sigla.Trim()))
                .ForMember(u => u.Login, opt => opt.MapFrom(v => v.Login.Trim()));
        }
    }
}
