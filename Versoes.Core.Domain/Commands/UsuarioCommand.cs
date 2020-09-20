using Flunt.Notifications;
using Flunt.Validations;
using Versoes.Core.Domain.ValueObjects;

namespace Versoes.Core.Domain.Commands
{
    public abstract class UsuarioCommand : CommandBase
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Sigla { get; protected set; }
        public int SetorId { get; protected set; }
        public StatusDeCadastro Status { get; protected set; } = StatusDeCadastro.Normal;
        public string Login { get; protected set; }
        public string Senha { get; protected set; }

        protected void ValidateId()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, Id, nameof(Id), "Id do usu�rio inv�lido")
            );
        }

        protected void ValidateSigla()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Sigla, nameof(Sigla), "Sigla � obrigat�rio")
                .HasMinLengthIfNotNullOrEmpty(Sigla, 2, nameof(Sigla), "Sigla deve ter no m�nimo 2 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(Sigla, 5, nameof(Sigla), "Sigla n�o pode ser maior que 5 caracteres.")
            );
        }

        protected void ValidateNome()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome � obrigat�rio")
                .HasMinLengthIfNotNullOrEmpty(Nome, 3, nameof(Nome), "Nome deve ter no m�nimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(Nome, 30, nameof(Nome), "Nome n�o pode ser maior que 30 caracteres.")
            );
        }

        protected void ValidateSetor()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, SetorId, nameof(SetorId), "Obrigat�rio informar um setor com id v�lido")
            );
        }

        protected void ValidateLogin()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Login, nameof(Login), "Login � obrigat�rio")
                .HasMinLengthIfNotNullOrEmpty(Login, 3, nameof(Login), "Login deve ter no m�nimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(Login, 20, nameof(Login), "Login n�o pode ser maior que 20 caracteres.")
            );
        }

        protected void ValidateNovaSenha()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Senha, nameof(Senha), "Senha � obrigat�rio")
                .Join(SenhaContract())
            );
        }

        protected void ValidateSenha()
        {
            AddNotifications(new Contract()
                .Join(SenhaContract())
            );
        }

        private Notifiable SenhaContract()
        {
            return new Contract()
                .HasMinLengthIfNotNullOrEmpty(Senha, 3, nameof(Senha), "Senha deve ter no m�nimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(Senha, 8, nameof(Senha), "Senha n�o pode ser maior que 8 caracteres.");
        }
    }
}