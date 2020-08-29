using Versoes.Entities;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public Setor Setor { get; set; }
        public StatusDeCadastro Status { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
