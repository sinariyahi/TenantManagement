using Contracts.Dto.AuditTrailsList;
using Contracts.Interface.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.AuditTrailsList
{
    public interface IAuditTrailsService 
    {
        Task<bool> AddAuditTrails(AuditTrails audit);
        Task<bool> UpdateAuditTrails(AuditTrails audit);
        Task<AuditTrails> GetAuditTrailsById(int id);
        Task<bool> DeleteAuditTrails(int id);
        Task<IEnumerable<AuditTrails>> GetAuditTrails();
    }
}
