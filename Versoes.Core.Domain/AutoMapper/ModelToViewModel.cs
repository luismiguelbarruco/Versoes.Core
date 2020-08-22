using AutoMapper;
using Versoes.Core.Domain.ViewModels;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.AutoMapper
{
    public class ModelToViewModel : Profile
    {
        public ModelToViewModel()
        {
            CreateMap<Projeto, ProjetoViewModel>();
            CreateMap<Setor, SetorViewModel>();
        }
    }
}
