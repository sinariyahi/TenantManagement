using Contracts.Dto.PublicHolidaysList;
using Contracts.Dto.SecurityLogsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.SecurityLogsList
{
    public interface ISecurityLogsService
    {
        Task<bool> AddSecurityLogs(SecurityLogs securityLogs);
        Task<bool> UpdateSecurityLogs(SecurityLogs securityLogs);
        Task<SecurityLogs> GetSecurityLogsById(int id);
        Task<bool> DeleteSecurityLogs(int id);
        Task<IEnumerable<SecurityLogs>> GetSecurityLogs();
    }
}
