using Contracts.Dto.PublicHolidaysList;
using Contracts.Dto.SecurityLogsList;
using Contracts.Interface.TenantManagement.PublicHolidaysList;
using Contracts.Interface.TenantManagement.SecurityLogsList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.SecurityLogsList
{
    [Route("api/SecurityLogs")]
    [ApiController]
    public class SecurityLogsController : ControllerBase
    {
        private readonly ISecurityLogsService _securityLogsService;
        public SecurityLogsController(ISecurityLogsService securityLogsService)
        {
            _securityLogsService = securityLogsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var securityLogs = await _securityLogsService.GetSecurityLogs();
            return Ok(securityLogs);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var securityLogs = await _securityLogsService.GetSecurityLogsById(id);
            if (securityLogs is null)
                return NotFound();
            return Ok(securityLogs);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SecurityLogs securityLogs)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _securityLogsService.AddSecurityLogs(securityLogs);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] SecurityLogs newSecurityLogs)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var securityLogs = await _securityLogsService.GetSecurityLogsById(id);
            if (securityLogs is null)
                return NotFound();
            newSecurityLogs.Id = id;
            var result = await _securityLogsService.UpdateSecurityLogs(newSecurityLogs);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var securityLogs = await _securityLogsService.GetSecurityLogsById(id);
            if (securityLogs is null)
                return NotFound();
            var result = await _securityLogsService.DeleteSecurityLogs(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
