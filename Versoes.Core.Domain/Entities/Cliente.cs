using System.Diagnostics.CodeAnalysis;

namespace Versoes.Entities.Models
{
    [ExcludeFromCodeCoverage]
    public class Cliente
    {
        public long Id { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
    }
}
