using Contracts.Dto.SecurityLogsList;
using Contracts.Dto.SendMessagesList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.SecurityLogsList;
using Contracts.Interface.TenantManagement.SendMessagesList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.SendMessagesList
{
    public class SendMessagesService : ISendMessagesService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public SendMessagesService(IGenericRepository repo)
        {
            _repo = repo;
        }
        
        public async Task<bool> AddSendMessages(SendMessages sendMessages)
        {
            try
            {
                string query = "insert into dbo.SendMessages(Id,CreationDate,ProjectId,ProjectIds,Message,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy) values(@Id,@CreationDate,@ProjectId,@ProjectIds,@Message,@CreatedDate,@CreatedBy,@ModifiedDate,@ModifiedBy)";
                await _repo.SaveData(query, new { Id = sendMessages.Id, CreationDate = sendMessages.CreationDate, ProjectId = sendMessages.ProjectId, ProjectIds = sendMessages.ProjectIds, Message = sendMessages.Message, CreatedDate = sendMessages.CreatedDate, CreatedBy = sendMessages.CreatedBy, ModifiedDate = sendMessages.ModifiedDate, ModifiedBy = sendMessages.ModifiedBy });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateSendMessages(SendMessages sendMessages)
        {
            try
            {
                string query = "update dbo.SendMessages set  CreationDate = @CreationDate, ProjectId = @ProjectId, ProjectIds = @ProjectIds, Message = @Message, CreatedDate = @CreatedDate, CreatedBy = @CreatedBy, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy where Id=@Id";
                await _repo.SaveData(query, sendMessages);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSendMessages(int id)
        {
            try
            {
                string query = "delete from dbo.SendMessages where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SendMessages>> GetSendMessages()
        {
            string query = "select * from dbo.SendMessages";
            var sendMessages = await _repo.GetData<SendMessages, dynamic>(query, new { });
            return sendMessages;
        }

        public async Task<SendMessages> GetSendMessagesById(int id)
        {
            string query = "select * from dbo.SendMessages where Id=@Id";
            IEnumerable<SendMessages> sendMessages = await _repo.GetData<SendMessages, dynamic>(query, new { Id = id });
            return sendMessages.FirstOrDefault();
        }
    }
}
