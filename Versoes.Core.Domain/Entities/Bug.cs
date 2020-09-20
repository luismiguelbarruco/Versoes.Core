using System.Diagnostics.CodeAnalysis;
using Versoes.Core.Domain.ValueObjects;

namespace Versoes.Entities.Models
{
    [ExcludeFromCodeCoverage]
    public class Bug : Lancamento
    {
        public Criticidade Criticidade { get; set; }
        public StatusDoBug Status { get; set; }
    }
}
