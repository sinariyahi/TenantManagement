using Contracts.Dto.ProgramSettingList;
using Contracts.Dto.ProjectsList;
using Contracts.Interface.TenantManagement.ProgramSettingList;
using Contracts.Interface.TenantManagement.ProjectsList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.ProjectsList
{
    [Route("api/Projects")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _projectsService;
        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var projects = await _projectsService.GetProjects();
            return Ok(projects);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var projects = await _projectsService.GetProjectsById(id);
            if (projects is null)
                return NotFound();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Projects projects)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _projectsService.AddProjects(projects);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] Projects newProjects)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var projects = await _projectsService.GetProjectsById(id);
            if (projects is null)
                return NotFound();
            newProjects.Id = id;
            var result = await _projectsService.UpdateProjects(newProjects);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var projects = await _projectsService.GetProjectsById(id);
            if (projects is null)
                return NotFound();
            var result = await _projectsService.DeleteProjects(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
