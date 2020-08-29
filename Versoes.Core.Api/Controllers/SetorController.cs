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

    [Route("api/setores")]
    [EnableCors("AllowSpecificOrigin")]
    [Authorize]
    [ApiController]
    public class SetorController : ApiController
    {
        private readonly ILogger _logger;
        private readonly ISetorSerive _setorSerive;

        public SetorController(ILogger logger, ISetorSerive setorSerive)
        {
            _logger = logger;
            _setorSerive = setorSerive;
        }

        [HttpGet]
        public async Task<IResult> Get()
        {
            try
            {
                var result = await _setorSerive.GetAllSetoresAsync();

                if (!result.Any())
                    return ViewModelResult("Não há setores cadastrados");

                return ViewModelResult(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao selecionar setores.");

                return ErrorResult("Falha ao selecionar setores");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IResult> Get(int id)
        {
            try
            {
                var result = await _setorSerive.GetSetorByIdAsync(id);

                if (result == null)
                    return ViewModelResult("Setor não encontrado");

                return ViewModelResult(result);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao selecionar Setor.");

                return ErrorResult("Falha ao selecionar Setor");
            }
        }

        [HttpPost]
        public async Task<IResult> Post([FromBody] SetorForCreationViewModel setorForCreationViewModel)
        {
            try
            {
                if (!ValidadeModel(setorForCreationViewModel))
                    return ValidationViewModelResult("Não foi possivel cadastrar setor", setorForCreationViewModel.Notifications);

                var result = await _setorSerive.InserirAsync(setorForCreationViewModel);

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao cadastrar setor.");

                return ErrorResult("Falha ao cadastrar setor");
            }
        }

        [HttpPut]
        public async Task<IResult> Put([FromBody] SetorForUpdateViewModel setorForUpdateViewModel)
        {
            try
            {
                if (!ValidadeModel(setorForUpdateViewModel))
                    return ValidationViewModelResult("Não foi possivel alterar setor", setorForUpdateViewModel.Notifications);

                var result = await _setorSerive.AtualizarAsync(setorForUpdateViewModel);

                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Falha ao atualizar setor.");

                return ErrorResult("Falha ao atualizar setor");
            }
        }
    }
}