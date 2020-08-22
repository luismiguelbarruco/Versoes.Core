
using System;
using System.Threading.Tasks;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Domain.Services
{
    public interface IUsuarioService : IDisposable
    {
        Task<IResult> InserirAsync(UsuarioForCreationViewModel usuarioForCreationViewModel);
        Task<IResult> AtualizarAsync(UsuarioForUpdateVireModel usuarioForUpdateVireModel);
    }
}
