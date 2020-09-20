using System.Collections.Generic;
using System.Threading.Tasks;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Repositories
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Task<IEnumerable<Usuario>> GetAllUsuariosAsync();
        Task<Usuario> GetUsuarioByIdAsync(long id);
        Task<Usuario> GetUsuarioByNomeAsync(string nome);
        Task<Usuario> GetSetorByNameAndDiferentIdAsync(long id, string nome);
        Task<Usuario> GetUsuarioByLoginAsync(string login);
        Task<Usuario> GetSetorByLoginAndDiferentIdAsync(long id, string login);
        Task<Usuario> GetUsuarioBySiglaAsync(string sigla);
        Task<Usuario> GetUsuarioBySiglaAndDiferentIdAsync(long id, string sigla);
        Task<Usuario> GetUsuarioAsync(string login, string password);
    }
}
