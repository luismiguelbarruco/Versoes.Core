using Flunt.Notifications;
using System.Collections.Generic;
using Versoes.Core.Domain.ResultComunication;

namespace Versoes.Core.Domain.Commands
{
    public class CommandResult : ResultBase
    {
        public CommandResult()
        {
        }

        public CommandResult(string message) 
            : base(message)
        {
        }

        public CommandResult(bool success, string message)
            : base(success, message)
        {
        }

        public CommandResult(bool success, string message, IReadOnlyCollection<Notification> notifications)
            : base(success, message, notifications)
        {
        }
    }
}
