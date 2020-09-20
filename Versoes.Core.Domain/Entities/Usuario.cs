using System.Diagnostics.CodeAnalysis;
using Versoes.Core.Domain.ValueObjects;

namespace Versoes.Entities.Models
{
    [ExcludeFromCodeCoverage]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusDeCadastro Status { get; set; }
        public string Sigla { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int SetorId { get; set; }
        public Setor Setor { get; set; }
    }
}
