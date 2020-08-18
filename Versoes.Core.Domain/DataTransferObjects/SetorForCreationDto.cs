using Versoes.Entities;
using System.ComponentModel.DataAnnotations;

namespace Versoes.Core.Domain.DataTransferObjects
{
    public class SetorForCreationDto
    {
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "Nome não pode ser maior que 100 caracteres.")]
        public string Nome { get; set; }

        [EnumDataType(typeof(StatusDeCadastro))]
        public StatusDeCadastro Status { get; set; }
    }
}
