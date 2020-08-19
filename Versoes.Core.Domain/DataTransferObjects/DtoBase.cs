using Flunt.Notifications;

namespace Versoes.Core.Domain.DataTransferObjects
{
    public abstract class DtoBase : Notifiable, IDto
    {
        public abstract void Validate();
    }
}