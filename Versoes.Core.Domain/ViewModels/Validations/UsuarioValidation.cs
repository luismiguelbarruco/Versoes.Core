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
                .HasMinLengthIfNotNullOrEmpty(_usuarioViewModel.Nome, 3, nameof(_usuarioViewModel.Nome), "Nome deve ter no mínimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(_usuarioViewModel.Nome, 30, nameof(_usuarioViewModel.Nome), "Nome não pode ser maior que 30 caracteres.")
            );
        }

        protected void ValidateSigla()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_usuarioViewModel.Sigla, nameof(_usuarioViewModel.Sigla), "Sigla é obrigatório")
                .HasMinLengthIfNotNullOrEmpty(_usuarioViewModel.Sigla, 2, nameof(_usuarioViewModel.Sigla), "Sigla deve ter no mínimo 2 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(_usuarioViewModel.Sigla, 5, nameof(_usuarioViewModel.Sigla), "Sigla não pode ser maior que 5 caracteres.")
            );
        }

        protected void ValidateSetor()
        {
            AddNotifications(new Contract()
                .Join(SetorContract())
            );
        }

        private Notifiable SetorContract()
        {
            if (_usuarioViewModel.Setor == null)
                return new Contract()
                    .IsNotNull(_usuarioViewModel.Setor, nameof(_usuarioViewModel.Setor), "Obrigatório informar um setor");

            return new Contract()
                .AreNotEquals(0, _usuarioViewModel.Setor.Id, nameof(_usuarioViewModel.Setor.Id), "Obrigatório informar um setor com id válido");
        }

        protected void ValidateLogin()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_usuarioViewModel.Login, nameof(_usuarioViewModel.Login), "Login é obrigatório")
                .HasMinLengthIfNotNullOrEmpty(_usuarioViewModel.Login, 3, nameof(_usuarioViewModel.Login), "Login deve ter no mínimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(_usuarioViewModel.Login, 20, nameof(_usuarioViewModel.Login), "Login não pode ser maior que 20 caracteres.")
            );
        }

        protected void ValidateNovaSenha()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_usuarioViewModel.Senha, nameof(_usuarioViewModel.Senha), "Senha é obrigatório")
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
                .HasMinLengthIfNotNullOrEmpty(_usuarioViewModel.Senha, 3, nameof(_usuarioViewModel.Senha), "Senha deve ter no mínimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(_usuarioViewModel.Senha, 8, nameof(_usuarioViewModel.Senha), "Senha não pode ser maior que 8 caracteres.");
        }
    }
}
