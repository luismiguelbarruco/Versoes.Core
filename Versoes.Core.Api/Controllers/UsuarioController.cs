using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Versoes.Core.Domain.Repositories;

namespace Versoes.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ILogger logger;
        private readonly IRepositoryWrapper repository;
        private readonly IMapper mapper;

        public UsuarioController(ILogger logger, IRepositoryWrapper repository, IMapper mapper)
        {
            this.logger = logger;
            this.repository = repository;
            this.mapper = mapper;
        }
    }
}