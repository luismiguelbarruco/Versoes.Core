using AutoMapper;
using Flunt.Notifications;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Versoes.Core.Domain.Commands;
using Versoes.Core.Domain.Commands.Validations;
using Versoes.Core.Domain.Handlers;
using Versoes.Core.Domain.Repositories;
using Versoes.Core.Domain.ResultComunication;
using Versoes.Core.Domain.ViewModels;
using Versoes.Entities.Models;

namespace Versoes.Core.Domain.Services
{
    public class UsuarioService : Notifiable, IUsuarioService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryWrapper _repository;
        private readonly ITokenService _tokenService;
        private readonly ICryptographyService _cryptographyService;

        public UsuarioService(IMapper mapper, IRepositoryWrapper repository, ITokenService tokenService, ICryptographyService cryptographyService)
        {
            _mapper = mapper;
            _repository = repository;
            _tokenService = tokenService;
            _cryptographyService = cryptographyService;
        }

        public string GenerateToken(Usuario usuario)
        {
            var token = _tokenService.GenerateToken(usuario);

            return token;
        }

        public UsuarioAutenticadoViewModel CreateUsuarioAutenticado(string token, Usuario usuario)
        {
            var usuarioViewModel = _mapper.Map<UsuarioViewModel>(usuario);

            var usuarioAutenticadoViewModel = new UsuarioAutenticadoViewModel
            {
                Token = token,
                UsuarioViewModel = usuarioViewModel
            };

            return usuarioAutenticadoViewModel;
        }

        public async Task<IEnumerable<UsuarioViewModel>> GetAllUsuaruiosAsync()
        {
            var usuarios = await _repository.Usuario.GetAllUsuariosAsync();

            var usuariosResult = _mapper.Map<IEnumerable<UsuarioViewModel>>(usuarios);

            return usuariosResult;
        }

        public async Task<UsuarioViewModel> GetUsuarioByIdAsync(long id)
        {
            var usuario = await _repository.Usuario.GetUsuarioByIdAsync(id);

            var usuarioResult = _mapper.Map<UsuarioViewModel>(usuario);

            return usuarioResult;
        }

        public async Task<Usuario> GetUsuarioAsync(string login, string password)
        {
            var passwordEncrypted = _cryptographyService.Encrypt(password);

            var usuario = await _repository.Usuario.GetUsuarioAsync(login, passwordEncrypted);

            return usuario;
        }

        public async Task<IResult> InserirAsync(UsuarioForCreationViewModel usuarioForCreationViewModel)
        {
            var cadastrarUsuarioCommand = _mapper.Map<CadastrarUsuarioCommand>(usuarioForCreationViewModel);

            var usuarioHandle = new UsuarioHandle(_mapper, _repository, _cryptographyService);

            var result = await usuarioHandle.Handler(cadastrarUsuarioCommand);

            return result;
        }

        public async Task<IResult> AtualizarAsync(UsuarioForUpdateViewModel usuarioForUpdateVireModel)
        {
            var alterarUsuarioCommand = _mapper.Map<AlterarUsuarioCommand>(usuarioForUpdateVireModel);

            var usuarioHandle = new UsuarioHandle(_mapper, _repository, _cryptographyService);

            var result = await usuarioHandle.Handler(alterarUsuarioCommand);

            return result;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}