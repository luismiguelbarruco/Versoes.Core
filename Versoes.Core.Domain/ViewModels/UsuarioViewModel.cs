using Flunt.Validations;
using Versoes.Entities;

namespace Versoes.Core.Domain.ViewModels
{
    public class UsuarioViewModel : ViewModelBase
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sigla { get; set; }
        public SetorViewModel Setor { get; set; }
        public StatusDeCadastro Status { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        public override bool ValidationResult => Valid;
        protected void ValidateId()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, Id, nameof(Id), "Id do usuário inválido")
            );
        }

        protected void ValidateNome()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome é obrigatório")
                .HasMaxLen(Nome, 100, nameof(Nome), "Nome não pode ser maior que 100 caracteres.")
            );
        }

        protected void ValidateSigla()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Sigla, nameof(Sigla), "Sigla é obrigatório")
                .HasMaxLen(Sigla, 100, nameof(Sigla), "Sigla não pode ser maior que 100 caracteres.")
            );
        }

        protected void ValidateSetor()
        {
            AddNotifications(new Contract()
                .IsNull(Setor, nameof(Setor), "Obrigatório informar um setor")
                .AreNotEquals(0, Setor.Id, nameof(Setor.Id), "Obrigatório informar um setor com id válido")
            );
        }

        protected void ValidateLogin()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Login, nameof(Login), "Login é obrigatório")
                .HasMaxLen(Nome, 20, nameof(Nome), "Login não pode ser maior que 20 caracteres.")
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
