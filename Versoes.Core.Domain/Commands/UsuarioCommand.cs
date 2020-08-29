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
                .AreNotEquals(0, Id, nameof(Id), "Id do usuário inválido")
            );
        }

        protected void ValidateSigla()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Sigla, nameof(Sigla), "Sigla é obrigatório")
                .HasMaxLen(Sigla, 100, nameof(Sigla), "Sigla não pode ser maior que 100 caracteres.")
            );
        }

        protected void ValidateNome()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome é obrigatório")
                .HasMaxLen(Nome, 100, nameof(Nome), "Nome não pode ser maior que 100 caracteres.")
            );
        }

        protected void ValidateSetor()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, SetorId, nameof(Setor.Id), "Obrigatório informar um setor com id válido")
            );
        }

        protected void ValidateLogin()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Login, nameof(Login), "Login é obrigatório")
                .HasMaxLen(Nome, 20, nameof(Login), "Login não pode ser maior que 20 caracteres.")
            );
        }

        protected void ValidateSenha()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Senha, nameof(Senha), "Senha é obrigatório")
                .HasMaxLen(Senha, 20, nameof(Senha), "Senha não pode ser maior que 20 caracteres.")
            );
        }
    }
}