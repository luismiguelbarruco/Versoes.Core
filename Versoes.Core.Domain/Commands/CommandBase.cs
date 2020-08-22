using Flunt.Notifications;
using System.Threading.Tasks;
using Versoes.Core.Domain.ResultComunication;

namespace Versoes.Core.Domain.Commands
{
    public abstract class CommandBase : Notifiable, ICommand
    {
        public abstract bool Validate();

        public virtual IResult ValidationResult { get; set; }
    }
}