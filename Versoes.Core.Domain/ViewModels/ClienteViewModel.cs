using System.Diagnostics.CodeAnalysis;

namespace Versoes.Core.Domain.ViewModels
{
    [ExcludeFromCodeCoverage]
    public class ClienteViewModel
    {
        public long Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
    }
}
