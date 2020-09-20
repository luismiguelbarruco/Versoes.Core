using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Versoes.Entities;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Usuario>> GetAllUsuariosAsync() =>
            await FindAll()
                .OrderBy(u => u.Nome)
                .Include(s => s.Setor)
                .ToListAsync();

        public async Task<Usuario> GetUsuarioByIdAsync(long id) =>
            await FindByCondition(u => u.Id == id)
                .Include(s => s.Setor)
                .FirstOrDefaultAsync();

        public async Task<Usuario> GetUsuarioByNomeAsync(string nome) =>
            await FindByCondition(u => u.Nome.Equals(nome))
                .FirstOrDefaultAsync();

        public async Task<Usuario> GetUsuarioBySiglaAsync(string sigla) =>
            await FindByCondition(u => u.Sigla.Equals(sigla))
                .FirstOrDefaultAsync();

        public async Task<Usuario> GetUsuarioByLoginAsync(string login) =>
            await FindByCondition(u => u.Login.Equals(login))
                .FirstOrDefaultAsync();

        public async Task<Usuario> GetUsuarioAsync(string login, string password) =>
            await FindByCondition(u => u.Login.Equals(login) && u.Senha.Equals(password))
                .Include(s => s.Setor)
                .FirstOrDefaultAsync();

        public async Task<Usuario> GetSetorByNameAndDiferentIdAsync(long id, string nome) =>
            await FindByCondition(u => u.Id != id && u.Nome.Equals(nome))
                .FirstOrDefaultAsync();

        public async Task<Usuario> GetSetorByLoginAndDiferentIdAsync(long id, string login) =>
            await FindByCondition(u => u.Id != id && u.Login.Equals(login))
                .FirstOrDefaultAsync();

        public async Task<Usuario> GetUsuarioBySiglaAndDiferentIdAsync(long id, string sigla) =>
            await FindByCondition(u => u.Id != id && u.Login.Equals(sigla))
                .FirstOrDefaultAsync();

        public new void Create(Usuario usuario)
        {
            RepositoryContext.Attach(usuario.Setor);

            base.Create(usuario);
        }
    }
}
