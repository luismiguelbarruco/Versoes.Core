using System.Diagnostics.CodeAnalysis;
using Versoes.Core.Domain.ValueObjects;

namespace Versoes.Entities.Models
{
    [ExcludeFromCodeCoverage]
    public class Setor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusDeCadastro Status { get; set; }
        //public Usuario Usuario { get; set; }
    }
}
