using System.ComponentModel.DataAnnotations;

namespace Versoes.Entities.DataTransferObjects
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
