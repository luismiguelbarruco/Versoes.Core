using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Versoes.Entities;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Repositories
{
    public class SetorRepository : RepositoryBase<Setor>, ISetorRepository
    {
        public SetorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Setor>> GetAllSetoresAsync() =>
            await FindAll()
                .OrderBy(setor => setor.Nome)
                .ToListAsync();

        public async Task<Setor> GetSetorByIdAsync(long id) =>
            await FindByCondition(setor => setor.Id == id)
                .FirstOrDefaultAsync();

        public async Task<Setor> GetSetorByNameAsync(string name) =>
            await FindByCondition(setor => setor.Nome.Equals(name))
                .FirstOrDefaultAsync();

        public async Task<Setor> GetSetorByNameAndDiferentIdAsync(string name, long id) =>
            await FindByCondition(setor => setor.Nome.Equals(name) && !setor.Id.Equals(id))
                .FirstOrDefaultAsync();
    }
}
