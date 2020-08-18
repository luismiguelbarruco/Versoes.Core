using Versoes.Entities;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.DataTransferObjects
{
    public class ProjetoDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public StatusDeCadastro Status { get; set; }
    }
}
