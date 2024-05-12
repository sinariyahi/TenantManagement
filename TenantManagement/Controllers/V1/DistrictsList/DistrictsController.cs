using Contracts.Dto.DiffCoefficientList;
using Contracts.Dto.DistrictsList;
using Contracts.Interface.TenantManagement.DiffCoefficientList;
using Contracts.Interface.TenantManagement.DistrictsList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.DistrictsList
{
    [Route("api/Districts")]
    [ApiController]
    public class DistrictsController : ControllerBase
    {
        private readonly IDistrictsService _districtsService;
        public DistrictsController(IDistrictsService districtsService)
        {
            _districtsService = districtsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var districts = await _districtsService.GetDistricts();
            return Ok(districts);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var districts = await _districtsService.GetDistrictsById(id);
            if (districts is null)
                return NotFound();
            return Ok(districts);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Districts districts)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _districtsService.AddDistricts(districts);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] Districts newDistricts)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var diffCoefficient = await _districtsService.GetDistrictsById(id);
            if (diffCoefficient is null)
                return NotFound();
            newDistricts.Id = id;
            var result = await _districtsService.UpdateDistricts(newDistricts);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var districts = await _districtsService.GetDistrictsById(id);
            if (districts is null)
                return NotFound();
            var result = await _districtsService.DeleteDistricts(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
