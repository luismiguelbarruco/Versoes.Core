
using System.Threading.Tasks;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.ResultComunication;

namespace Versoes.Core.Domain.Handlers
{
    public interface IHandle<T> where T : ICommand
    {
        Task<IResult> Handler(T command);
    }
}
