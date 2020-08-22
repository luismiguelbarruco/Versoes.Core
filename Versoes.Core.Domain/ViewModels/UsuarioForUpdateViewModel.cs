using Flunt.Notifications;
using System.Collections.Generic;

namespace Versoes.Core.Domain.ViewModels
{
    public class UsuarioForUpdateVireModel : UsuarioViewModel, IViewModel
    {
        public new IReadOnlyCollection<Notification> Notifications { get; set; }

        public bool Validate()
        {
            ValidateId();
            ValidateNome();
            ValidateSigla();
            ValidateSetor();
            ValidateLogin();
            ValidateSenha();

            return ValidationResult;
        }
    }
}
