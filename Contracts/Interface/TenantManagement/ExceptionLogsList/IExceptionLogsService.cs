using Contracts.Dto.DistrictsList;
using Contracts.Dto.ExceptionLogsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.ExceptionLogsList
{
    public interface IExceptionLogsService
    {
        Task<bool> AddExceptionLogs(ExceptionLogs exceptionLogs);
        Task<bool> UpdateExceptionLogs(ExceptionLogs exceptionLogs);
        Task<ExceptionLogs> GetExceptionLogsById(int id);
        Task<bool> DeleteExceptionLogs(int id);
        Task<IEnumerable<ExceptionLogs>> GetExceptionLogs();
    }
}
