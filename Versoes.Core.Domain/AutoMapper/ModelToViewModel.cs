using AutoMapper;
using System.Diagnostics.CodeAnalysis;
using Versoes.Core.Domain.ViewModels;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.AutoMapper
{
    [ExcludeFromCodeCoverage]
    public class ModelToViewModel : Profile
    {
        public ModelToViewModel()
        {
            CreateMap<Projeto, ProjetoViewModel>();
            CreateMap<Setor, SetorViewModel>();
            CreateMap<Usuario, UsuarioViewModel>()
                .ForPath(u => u.Senha, opt => opt.MapFrom(source => string.Empty));
        }
    }
}
