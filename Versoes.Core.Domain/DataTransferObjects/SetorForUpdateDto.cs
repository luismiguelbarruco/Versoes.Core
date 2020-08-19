using Versoes.Entities;
using Flunt.Validations;

namespace Versoes.Core.Domain.DataTransferObjects
{
    public class SetorForUpdateDto : DtoBase
    {
        public string Nome { get; set; }
        public StatusDeCadastro Status { get; set; } = StatusDeCadastro.Normal;

        public override void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome é obrigatório")
                .HasMaxLen(Nome, 100, nameof(Nome), "Nome não pode ser maior que 100 caracteres.")
            );
        }
    }
}
