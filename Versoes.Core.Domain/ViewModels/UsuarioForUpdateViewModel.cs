using Flunt.Notifications;
using System.Collections.Generic;
using Versoes.Core.Domain.ViewModels.Validations;

namespace Versoes.Core.Domain.ViewModels
{
    public class UsuarioForUpdateViewModel : UsuarioViewModel, IViewModel
    {
        public IReadOnlyCollection<Notification> Notifications { get; set; }

        public bool Validate()
        {
            var validation = new AlterarUsuarioValidation(this);

            if (validation.Invalid)
            {
                Notifications = validation.Notifications;
                return false;
            }

            return true;
        }
    }
}
