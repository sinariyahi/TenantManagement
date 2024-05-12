using Contracts.Dto.SecurityLogsList;
using Contracts.Dto.SendMessagesList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.SendMessagesList
{
    public interface ISendMessagesService
    {
        Task<bool> AddSendMessages(SendMessages sendMessages);
        Task<bool> UpdateSendMessages(SendMessages sendMessages);
        Task<SendMessages> GetSendMessagesById(int id);
        Task<bool> DeleteSendMessages(int id);
        Task<IEnumerable<SendMessages>> GetSendMessages();
    }
}
