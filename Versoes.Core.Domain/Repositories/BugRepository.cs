using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Versoes.Entities;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Repositories
{
    public class BugRepository : RepositoryBase<Bug>, IBugRepository
    {
        public BugRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Bug>> GetAllBugsAsync() =>
            await FindAll()
                .OrderBy(b => b.DataCriacao)
                .ToListAsync();

        public async Task<Bug> GetBugByIdAsync(long id) =>
            await FindByCondition(b => b.Id.Equals(id))
                .FirstOrDefaultAsync();

        public async Task<Bug> GetBugWithDetailsAsync(long id) =>
            await FindByCondition(b => b.Id.Equals(id))
            .Include(a => a.Anotacoes)
            .FirstOrDefaultAsync();
    }
}
