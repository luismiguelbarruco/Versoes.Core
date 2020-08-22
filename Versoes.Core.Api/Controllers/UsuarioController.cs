﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Threading.Tasks;
using Versoes.Core.Api.Controllers;
using Versoes.Core.Domain.Repositories;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.Services;
using Versoes.Core.Domain.ViewModels;

namespace Versoes.Api.Controllers
{
    [EnableCors("AllowSpecificOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(ILogger logger, IUsuarioService usuarioService)
        {
            _logger = logger;
            _usuarioService = usuarioService;
        }

        [HttpGet("usuario")]
        public async Task Get()
        {

        }

        [HttpGet("usuario/{id}")]
        public async Task Get(int id)
        {

        }

        [HttpPost]
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

        [HttpPut]
        public async Task<IResult> Put([FromBody] UsuarioForUpdateVireModel usuarioForUpdateVireModel)
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