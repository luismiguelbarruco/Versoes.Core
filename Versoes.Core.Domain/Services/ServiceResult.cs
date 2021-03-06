using Flunt.Notifications;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Versoes.Core.Domain.ResultComunication;

namespace Versoes.Core.Domain.Services
{
    [ExcludeFromCodeCoverage]
    public class ServiceResult : ResultBase
    {
        public ServiceResult()
        {
        }

        public ServiceResult(bool success, string message) 
            : base(success, message)
        {
        }

        public ServiceResult(bool success, string message, IReadOnlyCollection<Notification> notifications) 
            : base(success, message, notifications)
        {
        }
    }
}