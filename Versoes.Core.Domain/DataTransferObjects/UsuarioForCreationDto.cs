using Versoes.Entities;
using Flunt.Validations;

namespace Versoes.Core.Domain.DataTransferObjects
{
    public class UsuarioForCreationDto : DtoBase
    {
        public string Nome { get; set; }
        public SetorDto Setor { get; set; }
        public StatusDeCadastro Status { get; set; } = StatusDeCadastro.Normal;
        public string Login { get; set; }
        public string Senha { get; set; }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(Nome, nameof(Nome), "Nome é obrigatório")
                .HasMaxLen(Nome, 100, nameof(Nome), "Nome não pode ser maior que 100 caracteres.")
                .IsNull(Setor, nameof(Setor), "Obrigatório informar um setor")
                .AreNotEquals(0, Setor.Id, nameof(Setor.Id), "Obrigatório informar um setor com id válido")
                .IsNotNullOrEmpty(Login, nameof(Login), "Login é obrigatório")
                .HasMaxLen(Nome, 20, nameof(Nome), "Login não pode ser maior que 20 caracteres.")
                .IsNotNullOrEmpty(Senha, nameof(Senha), "Senha é obrigatório")
                .HasMaxLen(Senha, 20, nameof(Senha), "Senha não pode ser maior que 20 caracteres.")
            );
        }
    }
}
