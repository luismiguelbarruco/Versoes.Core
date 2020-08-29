using Flunt.Notifications;
using System.Collections.Generic;

namespace Versoes.Core.Domain.ViewModels
{
    public abstract class ViewModelBase //: IViewModel
    {
        public IReadOnlyCollection<Notification> Notifications { get; set; }

        //public bool Validate()
        //{
        //    //var validation = new AlterarSetorValidation(this);

        //    if (validation.Invalid)
        //    {
        //        Notifications = validation.Notifications;
        //        return false;
        //    }

        //    return true;
        //}
    }
}