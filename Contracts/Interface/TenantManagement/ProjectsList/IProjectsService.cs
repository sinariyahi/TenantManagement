using Contracts.Dto.ProgramSettingList;
using Contracts.Dto.ProjectsList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interface.TenantManagement.ProjectsList
{
    public interface IProjectsService
    {
        Task<bool> AddProjects(Projects projects);
        Task<bool> UpdateProjects(Projects projects);
        Task<Projects> GetProjectsById(int id);
        Task<bool> DeleteProjects(int id);
        Task<IEnumerable<Projects>> GetProjects();
    }
}
