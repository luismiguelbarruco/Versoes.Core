using Flunt.Notifications;
using System.Collections.Generic;

namespace Versoes.Core.Domain.Services
{
    public class ServiceResult : IServiceResult
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ServiceResult(){ }

        public ServiceResult(bool sucess, object data)
        {
            Sucess = sucess;
            Data = data;
        }

        public ServiceResult(bool sucess, string message)
        {
            Sucess = sucess;
            Message = message;
        }

        public ServiceResult(bool sucess, string message, IReadOnlyCollection<Notification> notifications)
            : this(sucess, notifications)
        {
            Sucess = sucess;
            Message = message;
        }
    }
}