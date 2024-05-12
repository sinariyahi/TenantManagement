using Contracts.Dto.DistrictsList;
using Contracts.Dto.ExceptionLogsList;
using Contracts.Interface.TenantManagement.DistrictsList;
using Contracts.Interface.TenantManagement.ExceptionLogsList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.ExceptionLogsList
{
    [Route("api/ExceptionLogs")]
    [ApiController]
    public class ExceptionLogsController : ControllerBase
    {
        private readonly IExceptionLogsService _exceptionLogsService;
        public ExceptionLogsController(IExceptionLogsService exceptionLogsService)
        {
            _exceptionLogsService = exceptionLogsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var exceptionLogs = await _exceptionLogsService.GetExceptionLogs();
            return Ok(exceptionLogs);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var exceptionLogs = await _exceptionLogsService.GetExceptionLogsById(id);
            if (exceptionLogs is null)
                return NotFound();
            return Ok(exceptionLogs);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ExceptionLogs exceptionLogs)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _exceptionLogsService.AddExceptionLogs(exceptionLogs);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] ExceptionLogs newExceptionLogs)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var exceptionLogs = await _exceptionLogsService.GetExceptionLogsById(id);
            if (exceptionLogs is null)
                return NotFound();
            newExceptionLogs.Id = id;
            var result = await _exceptionLogsService.UpdateExceptionLogs(newExceptionLogs);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var exceptionLogs = await _exceptionLogsService.GetExceptionLogsById(id);
            if (exceptionLogs is null)
                return NotFound();
            var result = await _exceptionLogsService.DeleteExceptionLogs(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
