

using Flunt.Notifications;
using System.Collections.Generic;

namespace Versoes.Core.Domain.ViewModels
{
    public class UsuarioForCreationViewModel : UsuarioViewModel, IViewModel
    {
        public new IReadOnlyCollection<Notification> Notifications { get; set; }

        public bool Validate()
        {
            ValidateNome();
            ValidateSigla();
            ValidateSetor();
            ValidateLogin();
            ValidateSenha();

            return ValidationResult;
        }
    }
}
