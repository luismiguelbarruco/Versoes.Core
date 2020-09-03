using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
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
    [Route("api/projetos")]
    [Authorize]
    [ApiController]
    public class ProjetoController : ApiController
    {
        private readonly ILogger _logger;
        private readonly IProjetoService _projetoService;

        public ProjetoController(ILogger logger, IProjetoService projetoService)
        {
            _logger = logger;
            _projetoService = projetoService;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                var result = await _projetoService.GetAllProjetosAsync();

                if (!result.Any())
                    return ViewModelResult("Não há projetos cadastrados");

                return ViewModelResult(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao selecionar projetos.");

                return ErrorResult("Falha ao selecionar projetos");
            }
        }

        [HttpGet("{id}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                var result = await _projetoService.GetAllProjetoByIdAsync(id);

                if (result == null)
                    return ViewModelResult("Projeto não encontrado");

                return ViewModelResult(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao selecionar projeto.");

                return ErrorResult("Falha ao selecionar projeto");
            }
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] ProjetoForCreationViewModel projetoForCreationViewModel)
        {
            try
            {
                if (!ValidadeModel(projetoForCreationViewModel))
                    return ValidationViewModelResult("Não foi possivel cadastrar projeto", projetoForCreationViewModel.Notifications);

                var result = await _projetoService.InserirAsync(projetoForCreationViewModel);

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao cadastrar projeto.");

                return ErrorResult("Falha ao cadastrar projeto");
            }
        }

        [HttpPut]
        public async Task<IResult> Put([FromBody] ProjetoForUpdateViewModel projetoForUpdateVireModel)
        {
            try
            {
                if (!ValidadeModel(projetoForUpdateVireModel))
                    return ValidationViewModelResult("Não foi possivel alterar projeto", projetoForUpdateVireModel.Notifications);

                var result = await _projetoService.AtualizarAsync(projetoForUpdateVireModel);

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao atualizar projeto.");

                return ErrorResult("Falha ao atualizar projeto");
            }
        }
    }
}