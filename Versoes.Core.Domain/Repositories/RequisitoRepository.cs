using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Versoes.Entities;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Repositories
{
    public class RequisitoRepository : RepositoryBase<Requisito>, IRequisitoRepository
    {
        public RequisitoRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Requisito>> GetAllRequisitosAsync() =>
            await FindAll()
            .OrderBy(r => r.DataCriacao)
            .ToListAsync();

        public async Task<Requisito> GetRequisitoByIdAsync(long id) =>
            await FindByCondition(r => r.Id.Equals(id))
            .FirstOrDefaultAsync();

        public async Task<Requisito> GetRequisitoWithDetailsAsync(long id) =>
            await FindByCondition(r => r.Id.Equals(id))
            .Include(a => a.Anotacoes)
            .FirstOrDefaultAsync();
    }
}
