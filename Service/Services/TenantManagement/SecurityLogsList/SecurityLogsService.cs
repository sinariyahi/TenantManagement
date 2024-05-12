using Contracts.Dto.PublicHolidaysList;
using Contracts.Dto.SecurityLogsList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.PublicHolidaysList;
using Contracts.Interface.TenantManagement.SecurityLogsList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.SecurityLogsList
{
    public class SecurityLogsService : ISecurityLogsService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public SecurityLogsService(IGenericRepository repo)
        {
            _repo = repo;
        }
        
        public async Task<bool> AddSecurityLogs(SecurityLogs securityLogs)
        {
            try
            {
                string query = "insert into dbo.SecurityLogs(Id,UserId,Action,IpAdress,DateTime,Browser,IsSuccess) values(@Id,@UserId,@Action,@IpAdress,@DateTime,@Browser,@IsSuccess)";
                await _repo.SaveData(query, new { Id = securityLogs.Id, UserId = securityLogs.UserId, Action = securityLogs.Action, IpAdress = securityLogs.IpAdress, DateTime = securityLogs.DateTime, Browser = securityLogs.Browser, IsSuccess = securityLogs.IsSuccess });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateSecurityLogs(SecurityLogs securityLogs)
        {
            try
            {
                string query = "update dbo.SecurityLogs set  UserId = @UserId, Action = @Action, IpAdress = @IpAdress, DateTime = @DateTime, Browser = @Browser, IsSuccess = @IsSuccess where Id=@Id";
                await _repo.SaveData(query, securityLogs);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteSecurityLogs(int id)
        {
            try
            {
                string query = "delete from dbo.SecurityLogs where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<SecurityLogs>> GetSecurityLogs()
        {
            string query = "select * from dbo.SecurityLogs";
            var securityLogs = await _repo.GetData<SecurityLogs, dynamic>(query, new { });
            return securityLogs;
        }

        public async Task<SecurityLogs> GetSecurityLogsById(int id)
        {
            string query = "select * from dbo.SecurityLogs where Id=@Id";
            IEnumerable<SecurityLogs> securityLogs = await _repo.GetData<SecurityLogs, dynamic>(query, new { Id = id });
            return securityLogs.FirstOrDefault();
        }
    }
}