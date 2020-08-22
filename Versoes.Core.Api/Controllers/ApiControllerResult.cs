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

        public ApiControllerResult(bool sucess, object data)
            : base(sucess, data)
        {
        }

        public ApiControllerResult(bool sucess, string message)
            : base(sucess, message)
        {
        }

        public ApiControllerResult(bool sucess, string message, IReadOnlyCollection<Notification> notifications) 
            : base(sucess, message, notifications)
        {
        }
    }
}
