using Flunt.Notifications;
using Flunt.Validations;
using Versoes.Entities;

namespace Versoes.Core.Domain.Commands
{
    public abstract class UsuarioCommand : CommandBase
    {
        public int Id { get; protected set; }
        public string Nome { get; protected set; }
        public string Sigla { get; protected set; }
        public int SetorId { get; protected set; }
        public StatusDeCadastro Status { get; protected set; }
        public string Login { get; protected set; }
        public string Senha { get; protected set; }

        protected void ValidateId()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, Id, nameof(Id), "Id do usuário inválido")
            );
        }

        protected void ValidateSigla()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Sigla, nameof(Sigla), "Sigla é obrigatório")
                .HasMinLengthIfNotNullOrEmpty(Sigla, 2, nameof(Sigla), "Sigla deve ter no mínimo 2 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(Sigla, 5, nameof(Sigla), "Sigla não pode ser maior que 5 caracteres.")
            );
        }

        protected void ValidateNome()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome é obrigatório")
                .HasMinLengthIfNotNullOrEmpty(Nome, 3, nameof(Nome), "Nome deve ter no mínimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(Nome, 30, nameof(Nome), "Nome não pode ser maior que 30 caracteres.")
            );
        }

        protected void ValidateSetor()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, SetorId, nameof(SetorId), "Obrigatório informar um setor com id válido")
            );
        }

        protected void ValidateLogin()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Login, nameof(Login), "Login é obrigatório")
                .HasMinLengthIfNotNullOrEmpty(Login, 3, nameof(Login), "Login deve ter no mínimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(Login, 20, nameof(Login), "Login não pode ser maior que 20 caracteres.")
            );
        }

        protected void ValidateNovaSenha()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Senha, nameof(Senha), "Senha é obrigatório")
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
                .HasMinLengthIfNotNullOrEmpty(Senha, 3, nameof(Senha), "Senha deve ter no mínimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(Senha, 8, nameof(Senha), "Senha não pode ser maior que 8 caracteres.");
        }
    }
}