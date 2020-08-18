using System.Threading.Tasks;

namespace Versoes.Contracts
{
    public interface IRepositoryWrapper
    {
        ISetorRepository Setor { get; }
        IUsuarioRepository Usuario { get; }
        IProjetoRepository Projeto { get; }
        IRequisitoRepository Requisito { get; }
        IBugRepository Bug { get; }

        Task SaveAsync();
    }
}
