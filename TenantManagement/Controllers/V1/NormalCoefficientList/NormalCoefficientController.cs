using Contracts.Dto.ExceptionLogsList;
using Contracts.Dto.NormalCoefficientList;
using Contracts.Interface.TenantManagement.ExceptionLogsList;
using Contracts.Interface.TenantManagement.NormalCoefficientList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.NormalCoefficientList
{
    [Route("api/NormalCoefficient")]
    [ApiController]
    public class NormalCoefficientController : ControllerBase
    {
        private readonly INormalCoefficientService _normalCoefficientService;
        public NormalCoefficientController(INormalCoefficientService normalCoefficientService)
        {
            _normalCoefficientService = normalCoefficientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var normalCoefficient = await _normalCoefficientService.GetNormalCoefficient();
            return Ok(normalCoefficient);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var normalCoefficient = await _normalCoefficientService.GetNormalCoefficientById(id);
            if (normalCoefficient is null)
                return NotFound();
            return Ok(normalCoefficient);
        }

        [HttpPost]
        public async Task<IActionResult> Post(NormalCoefficient normalCoefficient)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _normalCoefficientService.AddNormalCoefficient(normalCoefficient);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] NormalCoefficient newNormalCoefficient)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var normalCoefficient = await _normalCoefficientService.GetNormalCoefficientById(id);
            if (normalCoefficient is null)
                return NotFound();
            newNormalCoefficient.Id = id;
            var result = await _normalCoefficientService.UpdateNormalCoefficient(newNormalCoefficient);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var normalCoefficient = await _normalCoefficientService.GetNormalCoefficientById(id);
            if (normalCoefficient is null)
                return NotFound();
            var result = await _normalCoefficientService.DeleteNormalCoefficient(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
