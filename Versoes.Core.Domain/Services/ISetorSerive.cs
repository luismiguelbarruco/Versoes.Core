
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Domain.Services
{
    public interface ISetorSerive : IDisposable
    {
        Task<IEnumerable<SetorViewModel>> GetAllSetoresAsync();
        Task<SetorViewModel> GetSetorByIdAsync(long id);
        Task<IResult> InserirAsync(SetorForCreationViewModel setorForCreationVireModel);
        Task<IResult> AtualizarAsync(SetorForUpdateViewModel setorForUpdateViewModel);
    }
}
