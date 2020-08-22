using System.Collections.Generic;
using System.Threading.Tasks;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Repositories
{
    public interface ISetorRepository : IRepositoryBase<Setor>
    {
        Task<IEnumerable<Setor>> GetAllSetoresAsync();
        Task<Setor> GetSetorByIdAsync(long id);
        Task<Setor> GetSetorByNameAsync(string name);
        Task<Setor> GetSetorByNameAndDiferentIdAsync(string name, long id);
    }
}
