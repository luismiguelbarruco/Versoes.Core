using System.Collections.Generic;

namespace Versoes.Entities.Models
{
    public class Setor
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public StatusDeCadastro Status { get; set; }
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
