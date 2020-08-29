using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Services
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}
