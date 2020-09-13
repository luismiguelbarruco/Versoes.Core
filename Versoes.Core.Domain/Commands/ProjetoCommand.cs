using Flunt.Validations;
using Versoes.Entities;

namespace Versoes.Core.Domain.Commands
{
    public abstract class ProjetoCommand : CommandBase
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public StatusDeCadastro Status { get; protected set; }

        protected virtual void ValidateId()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, Id, nameof(Id), "Id do projeto inválido")
            );
        }

        protected virtual void ValidateNome()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome é obrigatório")
                .HasMinLengthIfNotNullOrEmpty(Nome, 3, nameof(Nome), "Nome deve ter no mínimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(Nome, 60, nameof(Nome), "Nome não pode ser maior que 60 caracteres.")
            );
        }
    }
}