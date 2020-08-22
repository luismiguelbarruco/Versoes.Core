using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Domain.Services
{
    public interface IProjetoService : IDisposable
    {
        Task<IEnumerable<ProjetoViewModel>> GetAllProjetosAsync();
        Task<ProjetoViewModel> GetAllProjetoByIdAsync(long id);
        Task<IResult> InserirAsync(ProjetoForCreationViewModel projetoForCreationViewModel);
        Task<IResult> AtualizarAsync(ProjetoForUpdateVireModel projetoForUpdateVireModel);
    }
}
