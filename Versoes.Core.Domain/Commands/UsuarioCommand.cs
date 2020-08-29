using Flunt.Validations;
using Versoes.Entities;
using Versoes.Entities.Models;

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
                .AreNotEquals(0, Id, nameof(Id), "Id do usu�rio inv�lido")
            );
        }

        protected void ValidateSigla()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Sigla, nameof(Sigla), "Sigla � obrigat�rio")
                .HasMaxLen(Sigla, 100, nameof(Sigla), "Sigla n�o pode ser maior que 100 caracteres.")
            );
        }

        protected void ValidateNome()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome � obrigat�rio")
                .HasMaxLen(Nome, 100, nameof(Nome), "Nome n�o pode ser maior que 100 caracteres.")
            );
        }

        protected void ValidateSetor()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, SetorId, nameof(Setor.Id), "Obrigat�rio informar um setor com id v�lido")
            );
        }

        protected void ValidateLogin()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Login, nameof(Login), "Login � obrigat�rio")
                .HasMaxLen(Nome, 20, nameof(Login), "Login n�o pode ser maior que 20 caracteres.")
            );
        }

        protected void ValidateSenha()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Senha, nameof(Senha), "Senha � obrigat�rio")
                .HasMaxLen(Senha, 20, nameof(Senha), "Senha n�o pode ser maior que 20 caracteres.")
            );
        }
    }
}