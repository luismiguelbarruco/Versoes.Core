using Flunt.Notifications;
using Flunt.Validations;

namespace Versoes.Core.Domain.ViewModels.Validations
{
    public class ProjetoValidation<TViewModel> : Notifiable where TViewModel : ProjetoViewModel
    {
        private readonly TViewModel _projetoViewModel;

        public ProjetoValidation(TViewModel viewModel) => _projetoViewModel = viewModel;

        protected void ValidateId()
        {
            AddNotifications(new Contract()
                .AreNotEquals(0, _projetoViewModel.Id, nameof(_projetoViewModel.Id), "Id do projeto inválido")
            );
        }

        protected void ValidateNome()
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(_projetoViewModel.Nome, nameof(_projetoViewModel.Nome), "Nome é obrigatório")
                .HasMinLengthIfNotNullOrEmpty(_projetoViewModel.Nome, 3, nameof(_projetoViewModel.Nome), "Nome deve ter no mínimo 3 caracteres.")
                .HasMaxLengthIfNotNullOrEmpty(_projetoViewModel.Nome, 60, nameof(_projetoViewModel.Nome), "Nome não pode ser maior que 60 caracteres.")
            );
        }
    }
}
