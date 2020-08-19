using Flunt.Notifications;
using Versoes.Core.Domain.DataTransferObjects;

namespace Versoes.Core.Domain.Services
{
    public class UsuarioService : Notifiable
    {
        public IServiceResult Inserir(UsuarioForCreationDto dto)
        {
            dto.Validate();

            if(dto.Invalid)
            {
                AddNotifications(dto);
                return new ServiceResult(false, "Não foi possivel cadastrar o usuário");
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
                return new ServiceResult(false, "Não foi possivel atualizar o usuário");
            }

            //implementar as demais validações

            return new ServiceResult();
        }
    }
}