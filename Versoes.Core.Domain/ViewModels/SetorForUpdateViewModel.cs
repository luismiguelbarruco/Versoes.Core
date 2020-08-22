using Flunt.Notifications;
using System.Collections.Generic;
using Versoes.Core.Domain.ViewModels.Validations;

namespace Versoes.Core.Domain.ViewModels
{
    public class SetorForUpdateViewModel : SetorViewModel, IViewModel
    {
        public IReadOnlyCollection<Notification> Notifications { get; set; }

        public bool Validate()
        {
            var validation = new AlterarSetorValidation(this);

            if (validation.Invalid)
            {
                Notifications = validation.Notifications;
                return false;
            }

            return true;
        }
    }
}
