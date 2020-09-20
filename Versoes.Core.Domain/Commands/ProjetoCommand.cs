using Flunt.Validations;
using Versoes.Core.Domain.ValueObjects;

namespace Versoes.Core.Domain.Commands
{
    public abstract class ProjetoCommand : CommandBase
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public StatusDeCadastro Status { get; protected set; } = StatusDeCadastro.Normal;

        protected virtual void ValidateId()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, Id, nameof(Id), "Id do projeto inv�lido")
            );
        }

        protected virtual void ValidateNome()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome � obrigat�rio")
                .HasMinLengthIfNotNullOrEmpty(Nome, 3, nameof(Nome), "Nome deve ter no m�nimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(Nome, 60, nameof(Nome), "Nome n�o pode ser maior que 60 caracteres.")
            );
        }
    }
}