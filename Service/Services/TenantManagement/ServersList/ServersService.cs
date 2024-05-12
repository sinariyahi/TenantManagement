using Contracts.Dto.SendMessagesList;
using Contracts.Dto.ServersList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.SendMessagesList;
using Contracts.Interface.TenantManagement.ServersList;
using Microsoft.AspNetCore.Hosting.Server;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.ServersList
{
    public class ServersService : IServersService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public ServersService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> AddServers(Servers servers)
        {
            try
            {
                string query = "insert into dbo.Servers(Id,OwnerType,Name,CreatedDate,CreatedBy,ModifiedDate,Modifiedby,IpAddress,AdminUserName,AdminPassword) values(@Id,@OwnerType,@Name,@CreatedDate,@CreatedBy,@ModifiedDate,@Modifiedby,@IpAddress,@AdminUserName,@AdminPassword)";
                await _repo.SaveData(query, new { Id = servers.Id, OwnerType = servers.OwnerType, Name = servers.Name, CreatedDate = servers.CreatedDate, CreatedBy = servers.CreatedBy, ModifiedDate = servers.ModifiedDate, Modifiedby = servers.Modifiedby, IpAddress = servers.IpAddress, AdminUserName = servers.AdminUserName, AdminPassword = servers.AdminPassword });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateServers(Servers servers)
        {
            try
            {
                string query = "update dbo.Servers set  OwnerType = @OwnerType, Name = @Name, CreatedDate = @CreatedDate, CreatedBy = @CreatedBy, ModifiedDate = @ModifiedDate, Modifiedby = @Modifiedby, IpAddress = @IpAddress, AdminUserName = @AdminUserName, AdminPassword = @AdminPassword where Id=@Id";
                await _repo.SaveData(query, servers);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteServers(int id)
        {
            try
            {
                string query = "delete from dbo.Servers where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Servers>> GetServers()
        {
            string query = "select * from dbo.Servers";
            var servers = await _repo.GetData<Servers, dynamic>(query, new { });
            return servers;
        }

        public async Task<Servers> GetServersById(int id)
        {
            string query = "select * from dbo.Servers where Id=@Id";
            IEnumerable<Servers> servers = await _repo.GetData<Servers, dynamic>(query, new { Id = id });
            return servers.FirstOrDefault();
        }

    }
}
