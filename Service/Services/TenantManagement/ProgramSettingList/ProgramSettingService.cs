using Contracts.Dto.NormalCoefficientList;
using Contracts.Dto.ProgramSettingList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.NormalCoefficientList;
using Contracts.Interface.TenantManagement.ProgramSettingList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.ProgramSettingList
{
    public class ProgramSettingService : IProgramSettingService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public ProgramSettingService(IGenericRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> AddProgramSetting(ProgramSetting programSetting)
        {
            try
            {
                string query = "insert into dbo.ProgramSetting(Id,Enable2FA,FaType) values(@Id,@Enable2FA,@FaType)";
                await _repo.SaveData(query, new { Id = programSetting.Id, Enable2FA = programSetting.Enable2FA, FaType = programSetting.FaType });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProgramSetting(ProgramSetting programSetting)
        {
            try
            {
                string query = "update dbo.ProgramSetting set  Enable2FA = @Enable2FA, FaType = @FaType where Id=@Id";
                await _repo.SaveData(query, programSetting);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProgramSetting(int id)
        {
            try
            {
                string query = "delete from dbo.ProgramSetting where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProgramSetting>> GetProgramSetting()
        {
            string query = "select * from dbo.ProgramSetting";
            var programSetting = await _repo.GetData<ProgramSetting, dynamic>(query, new { });
            return programSetting;
        }

        public async Task<ProgramSetting> GetProgramSettingById(int id)
        {
            string query = "select * from dbo.ProgramSetting where Id=@Id";
            IEnumerable<ProgramSetting> programSetting = await _repo.GetData<ProgramSetting, dynamic>(query, new { Id = id });
            return programSetting.FirstOrDefault();
        }
    }
}