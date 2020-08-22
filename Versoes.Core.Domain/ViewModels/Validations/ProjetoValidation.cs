using Flunt.Notifications;
using Flunt.Validations;

namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class ProjetoValidation<TViewModel> : Notifiable where TViewModel : ProjetoViewModel
    {
        private readonly TViewModel _setorViewModel;

        public ProjetoValidation(TViewModel viewModel) => _setorViewModel = viewModel;

        protected void ValidateId()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, _setorViewModel.Id, nameof(_setorViewModel.Id), "Id do projeto inválido")
            );
        }

        protected void ValidateNome()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_setorViewModel.Nome, nameof(_setorViewModel.Nome), "Nome é obrigatório")
                .HasMaxLen(_setorViewModel.Nome, 100, nameof(_setorViewModel.Nome), "Nome não pode ser maior que 100 caracteres.")
            );
        }
    }
}
