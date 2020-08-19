using Flunt.Notifications;
using Versoes.Core.Domain.DataTransferObjects;

namespace Versoes.Core.Domain.Services
{
    public class ProjetoService : Notifiable
    {
        public IServiceResult Inserir(ProjetoForCreationDto dto)
        {
            dto.Validate();

            if(dto.Invalid)
            {
                AddNotifications(dto);
                return new ServiceResult(false, "Não foi possivel cadastrar o projeto");
            }

            //implementar as demais validações

            return new ServiceResult();
        }

        public IServiceResult Atualizar(UsuarioForUpdateDto dto)
        {
            dto.Validate();

            if(dto.Invalid)
            {
                AddNotifications(dto);
                return new ServiceResult(false, "Não foi possivel atualizar o projeto");
            }

            //implementar as demais validações

            return new ServiceResult();
        }
    }
}