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
                .ToListAsync();

        public async Task<Usuario> GetUsuarioByIdAsync(long id) =>
            await FindByCondition(u => u.Id.Equals(id))
                .FirstOrDefaultAsync();

        public new void Create(Usuario usuario)
        {
            RepositoryContext.Attach(usuario.Setor);

            base.Create(usuario);
        }
    }
}
