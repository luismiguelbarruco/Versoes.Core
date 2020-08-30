using System.Collections.Generic;
using Flunt.Notifications;
using Versoes.Core.Domain.ViewModels.Validations;

namespace Versoes.Core.Domain.ViewModels
{
    public class LoginViewModel : IViewModel
    {
        public string Login { get; set; }
        public string Senha { get; set; }
        public IReadOnlyCollection<Notification> Notifications { get; set; }

        public bool Validate()
        {
            var validation = new LoginValidation(this);

            if (validation.Invalid)
            {
                Notifications = validation.Notifications;
                return false;
            }

            return true;
        }
    }
}
