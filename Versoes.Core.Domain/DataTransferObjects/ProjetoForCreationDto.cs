using Versoes.Entities;
using System.ComponentModel.DataAnnotations;

namespace Versoes.Core.Domain.DataTransferObjects
{
    public class ProjetoForCreationDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome não pode ser maior que 100 caracteres.")]
        public string Nome { get; set; }
        public StatusDeCadastro Status { get; set; }
    }
}
