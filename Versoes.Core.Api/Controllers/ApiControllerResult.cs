using Flunt.Notifications;
using System.Collections.Generic;
using Versoes.Core.Domain.ResultComunication;

namespace Versoes.Core.Api.Controllers
{
    public class ApiControllerResult : ResultBase
    {
        public ApiControllerResult()
        {
        }

        public ApiControllerResult(string message) 
            : base(message)
        {
        }

        public ApiControllerResult(bool success, object data)
            : base(success, data)
        {
        }

        public ApiControllerResult(bool success, string message)
            : base(success, message)
        {
        }

        public ApiControllerResult(bool success, string message, IReadOnlyCollection<Notification> notifications) 
            : base(success, message, notifications)
        {
        }
    }
}
