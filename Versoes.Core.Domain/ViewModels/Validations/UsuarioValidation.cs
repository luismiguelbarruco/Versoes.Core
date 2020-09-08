using Flunt.Notifications;
using Flunt.Validations;

namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class UsuarioValidation<TViewModel> : Notifiable where TViewModel : UsuarioViewModel
    {
        private readonly TViewModel _usuarioViewModel;

        public UsuarioValidation(TViewModel viewModel) => _usuarioViewModel = viewModel;

        protected void ValidateId()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, _usuarioViewModel.Id, nameof(_usuarioViewModel.Id), "Id do usuário inválido")
            );
        }

        protected void ValidateNome()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_usuarioViewModel.Nome, nameof(_usuarioViewModel.Nome), "Nome é obrigatório")
                .HasMaxLen(_usuarioViewModel.Nome, 100, nameof(_usuarioViewModel.Nome), "Nome não pode ser maior que 100 caracteres.")
            );
        }

        protected void ValidateSigla()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_usuarioViewModel.Sigla, nameof(_usuarioViewModel.Sigla), "Sigla é obrigatório")
                .HasMaxLen(_usuarioViewModel.Sigla, 100, nameof(_usuarioViewModel.Sigla), "Sigla não pode ser maior que 100 caracteres.")
            );
        }

        protected void ValidateSetor()
        {
            AddNotifications(new Contract()
                .IsNotNull(_usuarioViewModel.Setor, nameof(_usuarioViewModel.Setor), "Obrigatório informar um setor")
                .AreNotEquals(0, _usuarioViewModel.Setor.Id, nameof(_usuarioViewModel.Setor.Id), "Obrigatório informar um setor com id válido")
            );
        }

        protected void ValidateLogin()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_usuarioViewModel.Login, nameof(_usuarioViewModel.Login), "Login é obrigatório")
                .HasMaxLengthIfNotNullOrEmpty(_usuarioViewModel.Login, 20, nameof(_usuarioViewModel.Login), "Login não pode ser maior que 20 caracteres.")
            );
        }

        protected void ValidateNovaSenha()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_usuarioViewModel.Senha, nameof(_usuarioViewModel.Senha), "Senha é obrigatório")
                .HasMaxLengthIfNotNullOrEmpty(_usuarioViewModel.Senha, 8, nameof(_usuarioViewModel.Senha), "Senha não pode ser maior que 8 caracteres.")
            );
        }

        protected void ValidateSenha()
        {
            AddNotifications(new Contract()
                .HasMaxLengthIfNotNullOrEmpty(_usuarioViewModel.Senha, 8, nameof(_usuarioViewModel.Senha), "Senha não pode ser maior que 8 caracteres.")
            );
        }
    }
}
