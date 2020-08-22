using Flunt.Notifications;
using System.Collections.Generic;

namespace Versoes.Core.Domain.ResultComunication
{
    public abstract class ResultBase : IResult
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ResultBase() { }

        public ResultBase(string message)
        {
            Sucess = true;
            Message = message;
        }

        public ResultBase(bool sucess, object data)
        {
            Sucess = sucess;
            Data = data;
        }

        public ResultBase(bool sucess, string message)
        {
            Sucess = sucess;
            Message = message;
        }

        public ResultBase(bool sucess, string message, IReadOnlyCollection<Notification> notifications)
            : this(sucess, notifications)
        {
            Sucess = sucess;
            Message = message;
        }
    }
}
