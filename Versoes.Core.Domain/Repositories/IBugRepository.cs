using System.Collections.Generic;
using System.Threading.Tasks;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Repositories
{
    public interface IBugRepository : IRepositoryBase<Bug>
    {
        Task<Bug> GetBugByIdAsync(long id);
        Task<IEnumerable<Bug>> GetAllBugsAsync();
        Task<Bug> GetBugWithDetailsAsync(long id);
    }
}
