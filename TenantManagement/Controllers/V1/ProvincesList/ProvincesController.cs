using Contracts.Dto.ProjectsList;
using Contracts.Dto.ProvincesList;
using Contracts.Interface.TenantManagement.ProjectsList;
using Contracts.Interface.TenantManagement.ProvincesList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.ProvincesList
{
    [Route("api/Provinces")]
    [ApiController]
    public class ProvincesController : ControllerBase
    {
        private readonly IProvincesService _provincesService;
        public ProvincesController(IProvincesService provincesService)
        {
            _provincesService = provincesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var provinces = await _provincesService.GetProvinces();
            return Ok(provinces);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var provinces = await _provincesService.GetProvincesById(id);
            if (provinces is null)
                return NotFound();
            return Ok(provinces);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Provinces provinces)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _provincesService.AddProvinces(provinces);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] Provinces newProvinces)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var provinces = await _provincesService.GetProvincesById(id);
            if (provinces is null)
                return NotFound();
            newProvinces.Id = id;
            var result = await _provincesService.UpdateProvinces(newProvinces);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var provinces = await _provincesService.GetProvincesById(id);
            if (provinces is null)
                return NotFound();
            var result = await _provincesService.DeleteProvinces(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
