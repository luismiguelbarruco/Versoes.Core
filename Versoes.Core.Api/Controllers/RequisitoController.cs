using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Versoes.Contracts;

namespace Versoes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequisitoController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;

        public RequisitoController(ILogger logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }
    }
}