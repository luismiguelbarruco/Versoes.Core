using Flunt.Notifications;
using System.Collections.Generic;

namespace Versoes.Core.Domain.ViewModels
{
    public interface IViewModel
    {
        IReadOnlyCollection<Notification> Notifications { get; set; }
        bool Validate();
    }
}