using Versoes.Entities;

namespace Versoes.Core.Domain.ViewModels
{
    public class ProjetoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public StatusDeCadastro Status { get; set; } = StatusDeCadastro.Normal;
    }
}
