using Contracts.Dto.AuditTrailsList;
using Contracts.Dto.DiffCoefficientList;
using Contracts.Interface.TenantManagement.AuditTrailsList;
using Contracts.Interface.TenantManagement.DiffCoefficientList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.DiffCoefficientList
{
    [Route("api/DiffCoefficient")]
    [ApiController]
    public class DiffCoefficientController : ControllerBase
    {
        private readonly IDiffCoefficientService _diffCoefficientService;
        public DiffCoefficientController(IDiffCoefficientService diffCoefficientService)
        {
            _diffCoefficientService = diffCoefficientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var diffCoefficient = await _diffCoefficientService.GetDiffCoefficient();
            return Ok(diffCoefficient);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var diffCoefficient = await _diffCoefficientService.GetDiffCoefficientById(id);
            if (diffCoefficient is null)
                return NotFound();
            return Ok(diffCoefficient);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DiffCoefficient diffCoefficient)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _diffCoefficientService.AddDiffCoefficient(diffCoefficient);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] DiffCoefficient newDiffCoefficient)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var diffCoefficient = await _diffCoefficientService.GetDiffCoefficientById(id);
            if (diffCoefficient is null)
                return NotFound();
            newDiffCoefficient.Id = id;
            var result = await _diffCoefficientService.UpdateDiffCoefficient(newDiffCoefficient);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var auditTrails = await _diffCoefficientService.GetDiffCoefficientById(id);
            if (auditTrails is null)
                return NotFound();
            var result = await _diffCoefficientService.DeleteDiffCoefficient(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}