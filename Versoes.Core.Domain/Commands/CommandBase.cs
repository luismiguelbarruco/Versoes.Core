using Flunt.Notifications;
using System.Diagnostics.CodeAnalysis;
using Versoes.Core.Domain.ResultComunication;

namespace Versoes.Core.Domain.Commands
{
    [ExcludeFromCodeCoverage]
    public abstract class CommandBase : Notifiable, ICommand
    {
        public abstract bool Validate();

        public virtual IResult ValidationResult { get; set; }
    }
}