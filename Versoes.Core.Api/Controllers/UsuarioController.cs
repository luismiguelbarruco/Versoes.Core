using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using Versoes.Core.Api.Controllers;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.Services;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Api.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(
            ILogger logger,
            IUsuarioService usuarioService
        )
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IResult> Authenticate([FromBody] LoginViewModel loginViewModel)
        {
            try
            {
                if (!ValidadeModel(loginViewModel))
                    return ValidationViewModelResult("Não foi possivel realizar login", loginViewModel.Notifications);

                var usuario = await _usuarioService.GetUsuarioAsync(loginViewModel.Login, loginViewModel.Senha);

                if (usuario == null)
                    return ViewModelResult("login ou senha inválidos");

                var token = _usuarioService.GenerateToken(usuario);

                var usuarioAutenticado = _usuarioService.CreateUsuarioAutenticado(token, usuario);

                return ViewModelResult(usuarioAutenticado);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao fazer login.");

                return ErrorResult("Falha ao fazer login");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IResult> Get()
        {
            try
            {
                var result = await _usuarioService.GetAllUsuaruiosAsync();

                if (!result.Any())
                    return ViewModelResult("Não há usuários cadastrados");

                return ViewModelResult(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao selecionar usuários.");

                return ErrorResult("Falha ao selecionar usuários");
            }
        }

        [HttpGet("{id:int}")]
        [Authorize]
        public async Task<IResult> Get(int id)
        {
            try
            {
                var result = await _usuarioService.GetUsuarioByIdAsync(id);

                if (result == null)
                    return ViewModelResult("usuário não encontrado");

                return ViewModelResult(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao selecionar usuário.");

                return ErrorResult("Falha ao selecionar usuário");
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IResult> Post([FromBody] UsuarioForCreationViewModel usuarioForCreationViewModel)
        {
            try
            {
                if (!ValidadeModel(usuarioForCreationViewModel))
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

        [HttpPut]
        [Authorize]
        public async Task<IResult> Put([FromBody] UsuarioForUpdateViewModel usuarioForUpdateVireModel)
        {
            try
            {
                if (!ValidadeModel(usuarioForUpdateVireModel))
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