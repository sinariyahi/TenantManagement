using Contracts.Dto.DistrictsList;
using Contracts.Dto.ExceptionLogsList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.DistrictsList;
using Contracts.Interface.TenantManagement.ExceptionLogsList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.ExceptionLogsList
{
    public class ExceptionLogsService : IExceptionLogsService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public ExceptionLogsService(IGenericRepository repo)
        {
            _repo = repo;
        }
        
        public async Task<bool> AddExceptionLogs(ExceptionLogs exceptionLogs)
        {
            try
            {
                string query = "insert into dbo.ExceptionLogs(Id,ProjectId,TenantId,DateTime,Controller,Request,Exception,IsSolved,Explanation,SolvedBy) values(@Id,@ProjectId,@TenantId,@DateTime,@Controller,@Request,@Exception,@IsSolved,@Explanation,@SolvedBy)";
                await _repo.SaveData(query, new { Id = exceptionLogs.Id, ProjectId = exceptionLogs.ProjectId, TenantId = exceptionLogs.TenantId, DateTime = exceptionLogs.DateTime, Controller = exceptionLogs.Controller, Request = exceptionLogs.Request, Exception = exceptionLogs.Exception, IsSolved = exceptionLogs.IsSolved, Explanation = exceptionLogs.Explanation, SolvedBy = exceptionLogs.SolvedBy });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateExceptionLogs(ExceptionLogs exceptionLogs)
        {
            try
            {
                string query = "update dbo.ExceptionLogs set  ProjectId = @ProjectId, TenantId = @TenantId, DateTime = @DateTime, Controller = @Controller, Request = @Request, Exception = @Exception, IsSolved = @IsSolved, Explanation = @Explanation, SolvedBy = @SolvedBy where Id=@Id";
                await _repo.SaveData(query, exceptionLogs);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteExceptionLogs(int id)
        {
            try
            {
                string query = "delete from dbo.ExceptionLogs where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ExceptionLogs>> GetExceptionLogs()
        {
            string query = "select * from dbo.ExceptionLogs";
            var exceptionLogs = await _repo.GetData<ExceptionLogs, dynamic>(query, new { });
            return exceptionLogs;
        }

        public async Task<ExceptionLogs> GetExceptionLogsById(int id)
        {
            string query = "select * from dbo.ExceptionLogs where Id=@Id";
            IEnumerable<ExceptionLogs> exceptionLogs = await _repo.GetData<ExceptionLogs, dynamic>(query, new { Id = id });
            return exceptionLogs.FirstOrDefault();
        }
    }
}
