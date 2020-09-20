using System.Diagnostics.CodeAnalysis;
using Versoes.Core.Domain.ValueObjects;

namespace Versoes.Entities.Models
{
    [ExcludeFromCodeCoverage]
    public class Requisito : Lancamento
    {
        public string Motivacao { get; set; }
        public ushort ValorAgregado { get; set; }
        public Prioridade Prioridade { get; set; }
        public StatusDoRequisito Status { get; set; }
    }
}
