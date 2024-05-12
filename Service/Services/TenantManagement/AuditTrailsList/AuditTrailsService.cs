using Contracts.Dto.AuditTrailsList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.AuditTrailsList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.AuditTrailsList
{
    public class AuditTrailsService : IAuditTrailsService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public AuditTrailsService(IGenericRepository repo)
        {
            _repo = repo;
        }
        public async Task<bool> AddAuditTrails(AuditTrails audit)
        {
            try
            {
                string query = "insert into dbo.AuditTrails(Id,UserId,Type,TableName,PrimaryKey,DateTime,OldValues,NewValues,AffectedColumns) values(@Id,@UserId,@Type,@TableName,@PrimaryKey,@DateTime,@OldValues,@NewValues,@AffectedColumns)";
                await _repo.SaveData(query, new { Id = audit.Id, UserId = audit.UserId, Type = audit.Type, TableName = audit.TableName, PrimaryKey = audit.PrimaryKey, DateTime = audit.DateTime, OldValues = audit.OldValues, NewValues = audit.NewValues, AffectedColumns = audit.AffectedColumns});
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateAuditTrails(AuditTrails audit)
        {
            try
            {
                string query = "update dbo.AuditTrails set UserId = @UserId,Type = @Type,TableName = @TableName,PrimaryKey = @PrimaryKey,DateTime = @DateTime,OldValues = @OldValues,NewValues = @NewValues,AffectedColumns = @AffectedColumns where Id=@Id";
                await _repo.SaveData(query, audit);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteAuditTrails(int id)
        {
            try
            {
                string query = "delete from dbo.AuditTrails where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<AuditTrails>> GetAuditTrails()
        {
            string query = "select * from dbo.AuditTrails";
            var auditTrails = await _repo.GetData<AuditTrails, dynamic>(query, new { });
            return auditTrails;
        }

        public async Task<AuditTrails> GetAuditTrailsById(int id)
        {
            string query = "select * from dbo.AuditTrails where Id=@Id";
            IEnumerable<AuditTrails> auditTrails = await _repo.GetData<AuditTrails, dynamic>(query, new { Id = id });
            return auditTrails.FirstOrDefault();
        }
    }
}
