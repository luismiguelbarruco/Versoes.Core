using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Core.Api.Controllers
{
    public class ApiController : ControllerBase
    {
        public bool ValidadeModel(IViewModel viewModel) => viewModel.Validate();

        public IResult ErrorResult(string error)
        {
            return new ApiControllerResult(false, error);
        }

        public IResult ViewModelResult(object result)
        {
            return new ApiControllerResult(true, result);
        }

        public IResult ViewModelResult(IEnumerable<object> objects)
        {
            return new ApiControllerResult(true, objects);
        }

        public IResult ViewModelResult(string message)
        {
            return new ApiControllerResult(false, message);
        }

        public IResult ValidationViewModelResult(string error, IReadOnlyCollection<Notification> notifications)
        {
            return new ApiControllerResult(false, error, notifications);
        }
    }
}
