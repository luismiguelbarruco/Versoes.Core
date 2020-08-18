using Versoes.Entities;

namespace Versoes.Core.Domain.DataTransferObjects
{
    public class SetorDto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public StatusDeCadastro Status { get; set; }
    }
}
