using Contracts.Dto.NormalCoefficientList;
using Contracts.Dto.ProgramSettingList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.ProgramSettingList
{
    public interface IProgramSettingService
    {
        Task<bool> AddProgramSetting(ProgramSetting programSetting);
        Task<bool> UpdateProgramSetting(ProgramSetting programSetting);
        Task<ProgramSetting> GetProgramSettingById(int id);
        Task<bool> DeleteProgramSetting(int id);
        Task<IEnumerable<ProgramSetting>> GetProgramSetting();
    }
}
