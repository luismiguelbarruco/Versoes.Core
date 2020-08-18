using System.Collections.Generic;
using System.Threading.Tasks;
using Versoes.Entities.Models;

namespace Versoes.Contracts
{
    public interface IRequisitoRepository : IRepositoryBase<Requisito>
    {
        Task<IEnumerable<Requisito>> GetAllRequisitosAsync();
        public Task<Requisito> GetRequisitoByIdAsync(long id);
        public Task<Requisito> GetRequisitoWithDetailsAsync(long id);
    }
}
