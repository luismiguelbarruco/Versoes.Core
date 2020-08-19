using Flunt.Notifications;
using Versoes.Core.Domain.DataTransferObjects;

namespace Versoes.Core.Domain.Services
{
    public class SetorSerive : Notifiable
    {
        public IServiceResult Inserir(SetorForCreationDto dto)
        {
            dto.Validate();

            if(dto.Invalid)
            {
                AddNotifications(dto);
                return new ServiceResult(false, "Não foi possivel cadastrar o setor");
            }

            //implementar as demais validações

            return new ServiceResult();
        }

        public IServiceResult Atualizar(SetorForUpdateDto dto)
        {
            dto.Validate();

            if(dto.Invalid)
            {
                AddNotifications(dto);
                return new ServiceResult(false, "Não foi possivel atualizar o setor");
            }

            //implementar as demais validações

            return new ServiceResult();
        }        
    }
}