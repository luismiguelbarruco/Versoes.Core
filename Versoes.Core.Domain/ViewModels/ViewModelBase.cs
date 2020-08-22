using Flunt.Notifications;

namespace Versoes.Core.Domain.ViewModels
{
    public abstract class ViewModelBase : Notifiable
    {
        public abstract bool ValidationResult { get; }
    }
}