using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.ViewModels;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Services
{
    public interface IUsuarioService : IDisposable
    {
        string GenerateToken(Usuario usuario);
        UsuarioAutenticadoViewModel CreateUsuarioAutenticado(string token, Usuario usuario);
        Task<IEnumerable<UsuarioViewModel>> GetAllUsuaruiosAsync();
        Task<UsuarioViewModel> GetUsuarioByIdAsync(long id);
        Task<Usuario> GetUsuarioAsync(string login, string password);
        Task<IResult> InserirAsync(UsuarioForCreationViewModel usuarioForCreationViewModel);
        Task<IResult> AtualizarAsync(UsuarioForUpdateViewModel usuarioForUpdateVireModel);
    }
}
