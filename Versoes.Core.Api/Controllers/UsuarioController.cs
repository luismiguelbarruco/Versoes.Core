using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using Versoes.Core.Api.Controllers;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.Services;
using Versoes.Core.Domain.ViewModels;
using Versoes.Entities.Models;

namespace Versoes.Api.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api")]
    [ApiController]
    public class UsuarioController : ApiController
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(
            ILogger logger, 
            IUsuarioService usuarioService, 
            SignInManager<Usuario> signInManager,
            UserManager<Usuario> userManager
        )
        {
            _logger = logger;
            _usuarioService = usuarioService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet("usuario")]
        public async Task Get()
        {

        }

        [HttpGet("usuario/{id}")]
        public async Task Get(int id)
        {

        }

        [HttpPost("usuario")]
        public async Task<IResult> Post([FromBody] UsuarioForCreationViewModel usuarioForCreationViewModel)
        {
            try
            {
                if (usuarioForCreationViewModel.Invalid)
                    return ValidationViewModelResult("Não foi possivel cadastrar usuário", usuarioForCreationViewModel.Notifications);

                var result = await _usuarioService.InserirAsync(usuarioForCreationViewModel);

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao cadastrar usuário.");

                return ErrorResult("Falha ao cadastrar usuário");
            }
        }

<<<<<<< HEAD
        [HttpPut("usuario")]
=======
        [HttpPut]
>>>>>>> 0a70d4a91c4b17cda9351c33c8dd759adda7bec8
        public async Task<IResult> Put([FromBody] UsuarioForUpdateViewModel usuarioForUpdateVireModel)
        {
            try
            {
                if (usuarioForUpdateVireModel.Invalid)
                    return ValidationViewModelResult("Não foi possivel alterar usuário", usuarioForUpdateVireModel.Notifications);

                var result = await _usuarioService.AtualizarAsync(usuarioForUpdateVireModel);

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao atualizar usuário.");

                return ErrorResult("Falha ao atualizar usuário");
            }
        }
    }
}