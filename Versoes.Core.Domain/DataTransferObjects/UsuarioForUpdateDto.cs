using Versoes.Entities;
using System.ComponentModel.DataAnnotations;

namespace Versoes.Core.Domain.DataTransferObjects
{
    public class UsuarioForUpdateDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome não pode ser maior que 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Setor obrigatório")]
        public SetorDto Setor { get; set; }

        public StatusDeCadastro Status { get; set; }

        [Required(ErrorMessage = "Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Senha { get; set; }
    }
}
