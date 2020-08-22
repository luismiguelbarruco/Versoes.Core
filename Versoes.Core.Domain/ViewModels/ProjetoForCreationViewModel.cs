using Flunt.Notifications;
using System.Collections.Generic;
using Versoes.Core.Domain.ViewModels.Validations;

namespace Versoes.Core.Domain.ViewModels
{
    public class ProjetoForCreationViewModel : ProjetoViewModel, IViewModel
    {
        public IReadOnlyCollection<Notification> Notifications { get; set; }

        public bool Validate()
        {
            var validation = new CadastrarProjetoValidation(this);

            if (validation.Invalid)
            {
                Notifications = validation.Notifications;
                return false;
            }

            return true;
        }
    }
}
