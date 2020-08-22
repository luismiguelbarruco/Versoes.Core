using Flunt.Notifications;
using System.Collections.Generic;
using Versoes.Core.Domain.ResultComunication;

namespace Versoes.Core.Domain.Services
{
    public class ServiceResult : ResultBase
    {
        public ServiceResult()
        {
        }

        public ServiceResult(bool sucess, string message) 
            : base(sucess, message)
        {
        }

        public ServiceResult(bool sucess, string message, IReadOnlyCollection<Notification> notifications) 
            : base(sucess, message, notifications)
        {
        }
    }
}