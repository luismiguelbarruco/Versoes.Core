using System.Diagnostics.CodeAnalysis;
using Versoes.Core.Domain.ValueObjects;

namespace Versoes.Entities.Models
{
    [ExcludeFromCodeCoverage]
    public class Projeto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public StatusDeCadastro Status { get; set; }
    }
}
