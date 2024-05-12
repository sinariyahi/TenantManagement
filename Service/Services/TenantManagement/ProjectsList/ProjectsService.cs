using Contracts.Dto.ProgramSettingList;
using Contracts.Dto.ProjectsList;
using Contracts.Interface.Shared;
using Contracts.Interface.TenantManagement.ProgramSettingList;
using Contracts.Interface.TenantManagement.ProjectsList;
using Service.Service.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.TenantManagement.ProjectsList
{
    public class ProjectsService : IProjectsService, IBaseService
    {
        private readonly IGenericRepository _repo;
        public ProjectsService(IGenericRepository repo)
        {
            _repo = repo;
        }

    
        public async Task<bool> AddProjects(Projects projects)
        {
            try
            {
                string query = "insert into dbo.Projects(Id ,CreationDate , Version , Name , ProjectUrl , ProjectCode , ProjectName , Explanation , CreatedDate , CreatedBy , ModifiedDate , ModifiedBy , IsActive) values(@Id,@CreationDate , @Version , @Name , @ProjectUrl , @ProjectCode , @ProjectName , @Explanation , @CreatedDate , @CreatedBy , @ModifiedDate , @ModifiedBy , @IsActive )";
                await _repo.SaveData(query, new { Id = projects.Id, CreationDate = projects.CreationDate, Version = projects.Version, Name = projects.Name, ProjectUrl = projects.ProjectUrl, ProjectCode = projects.ProjectCode, ProjectName = projects.ProjectName, Explanation = projects.Explanation, CreatedDate = projects.CreatedDate, CreatedBy = projects.CreatedBy, ModifiedDate = projects.ModifiedDate, ModifiedBy = projects.ModifiedBy, IsActive = projects.IsActive });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UpdateProjects(Projects projects)
        {
            try
            {
                string query = "update dbo.Projects set  CreationDate = @CreationDate, Version = @Version, Name = @Name, ProjectUrl = @ProjectUrl, ProjectCode = @ProjectCode, ProjectName = @ProjectName, Explanation = @Explanation, CreatedDate = @CreatedDate, CreatedBy = @CreatedBy, ModifiedDate = @ModifiedDate, ModifiedBy = @ModifiedBy, IsActive = @IsActive where Id=@Id";
                await _repo.SaveData(query, projects);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteProjects(int id)
        {
            try
            {
                string query = "delete from dbo.Projects where id = @Id";
                await _repo.SaveData(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Projects>> GetProjects()
        {
            string query = "select * from dbo.Projects";
            var projects = await _repo.GetData<Projects, dynamic>(query, new { });
            return projects;
        }

        public async Task<Projects> GetProjectsById(int id)
        {
            string query = "select * from dbo.Projects where Id=@Id";
            IEnumerable<Projects> projects = await _repo.GetData<Projects, dynamic>(query, new { Id = id });
            return projects.FirstOrDefault();
        }
    }
}