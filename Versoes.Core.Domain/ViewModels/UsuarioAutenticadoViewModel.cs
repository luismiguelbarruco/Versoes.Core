using System.Diagnostics.CodeAnalysis;

namespace Versoes.Core.Domain.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class UsuarioAutenticadoViewModel
    {
        public string Token { get; set; }
        public UsuarioViewModel UsuarioViewModel { get; set; }
    }
}
