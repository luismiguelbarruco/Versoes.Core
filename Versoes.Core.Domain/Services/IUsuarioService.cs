using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Domain.Services
{
    public interface IUsuarioService : IDisposable
    {
        Task<IEnumerable<UsuarioViewModel>> GetAllUsuaruiosAsync();
        Task<UsuarioViewModel> GetUsuaruiByIdAsync(long id);
        Task<IResult> InserirAsync(UsuarioForCreationViewModel usuarioForCreationViewModel);
        Task<IResult> AtualizarAsync(UsuarioForUpdateViewModel usuarioForUpdateVireModel);
    }
}
