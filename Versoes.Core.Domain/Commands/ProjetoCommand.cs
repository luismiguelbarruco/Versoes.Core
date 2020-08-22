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
                .AreNotEquals(0, Id, nameof(Id), "Id do setor inválido")
            );
        }

        protected virtual void ValidateNome()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome é obrigatório")
                .HasMaxLen(Nome, 100, nameof(Nome), "Nome não pode ser maior que 100 caracteres.")
            );
        }
    }
}