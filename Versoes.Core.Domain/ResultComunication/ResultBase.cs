using Flunt.Notifications;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Versoes.Core.Domain.ResultComunication
{
    [ExcludeFromCodeCoverage]
    public abstract class ResultBase : IResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public ResultBase() { }

        public ResultBase(string message)
        {
            Success = true;
            Message = message;
        }

        public ResultBase(bool success, object data)
        {
            Success = success;
            Data = data;
        }

        public ResultBase(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public ResultBase(bool success, string message, IReadOnlyCollection<Notification> notifications)
            : this(success, notifications)
        {
            Success = success;
            Message = message;
        }
    }
}
