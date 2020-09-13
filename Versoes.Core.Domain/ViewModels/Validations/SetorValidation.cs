using Flunt.Notifications;
using Flunt.Validations;

namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class SetorValidation<TViewModel> : Notifiable where TViewModel : SetorViewModel
    {
        private readonly TViewModel _setorViewModel;

        public SetorValidation(TViewModel viewModel) => _setorViewModel = viewModel;

        protected void ValidateId()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, _setorViewModel.Id, nameof(_setorViewModel.Id), "Id do setor inválido")
            );
        }

        protected void ValidateNome()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_setorViewModel.Nome, nameof(_setorViewModel.Nome), "Nome é obrigatório")
                .HasMinLengthIfNotNullOrEmpty(_setorViewModel.Nome, 3, nameof(_setorViewModel.Nome), "Nome deve ter no mínimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(_setorViewModel.Nome, 30, nameof(_setorViewModel.Nome), "Nome não pode ser maior que 30 caracteres.")
            );
        }
    }
}
