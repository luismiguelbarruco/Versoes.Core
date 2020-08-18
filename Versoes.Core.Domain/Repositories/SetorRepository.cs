using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Versoes.Contracts;
using Versoes.Entities;
using Versoes.Entities.Models;

namespace Versoes.Repositories
{
    public class SetorRepository : RepositoryBase<Setor>, ISetorRepository
    {
        public SetorRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Setor>> GetAllSetoresAsync()
        {
            return await FindAll()
                .OrderBy(setor => setor.Nome)
                .ToListAsync();
        }

        public async Task<Setor> GetSetorByIdAsync(long id)
        {
            return await FindByCondition(setor => setor.Id.Equals(id))
                .FirstOrDefaultAsync();
        }
    }
}
