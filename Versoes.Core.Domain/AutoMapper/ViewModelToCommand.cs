using AutoMapper;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.Commands.Validations;
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

            CreateMap<ProjetoForUpdateViewModel, AlterarProjetoCommand>()
                .ConstructUsing(p => new AlterarProjetoCommand(p.Id, p.Nome, p.Status))
                .ForMember(p => p.ValidationResult, opt => opt.Ignore());

            CreateMap<SetorForCreationViewModel, CadastrarSetorCommand>()
                .ConstructUsing(s => new CadastrarSetorCommand(s.Nome, s.Status))
                .ForMember(s => s.ValidationResult, opt => opt.Ignore());

            CreateMap<SetorForUpdateViewModel, AlterarSetorCommand>()
                .ConstructUsing(s => new AlterarSetorCommand(s.Id, s.Nome, s.Status))
                .ForMember(s => s.ValidationResult, opt => opt.Ignore());

            CreateMap<UsuarioForCreationViewModel, CadastrarUsuarioCommand>()
                .ConstructUsing(u => new CadastrarUsuarioCommand(u.Nome, u.Sigla, u.Setor.Id, u.Status, u.Login, u.Senha))
                .ForMember(u => u.ValidationResult, opt => opt.Ignore());

            CreateMap<UsuarioForUpdateViewModel, AlterarUsuarioCommand>()
                .ConstructUsing(u => new AlterarUsuarioCommand(u.Id, u.Nome, u.Sigla, u.Setor.Id, u.Status, u.Login, u.Senha))
                .ForMember(u => u.ValidationResult, opt => opt.Ignore());
        }
    }
}
