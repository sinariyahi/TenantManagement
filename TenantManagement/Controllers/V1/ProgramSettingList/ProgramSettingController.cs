using Contracts.Dto.NormalCoefficientList;
using Contracts.Dto.ProgramSettingList;
using Contracts.Interface.TenantManagement.NormalCoefficientList;
using Contracts.Interface.TenantManagement.ProgramSettingList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.ProgramSettingList
{
    [Route("api/ProgramSetting")]
    [ApiController]
    public class ProgramSettingController : ControllerBase
    {
        private readonly IProgramSettingService _programSettingService;
        public ProgramSettingController(IProgramSettingService programSettingService)
        {
            _programSettingService = programSettingService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var programSetting = await _programSettingService.GetProgramSetting();
            return Ok(programSetting);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var programSetting = await _programSettingService.GetProgramSettingById(id);
            if (programSetting is null)
                return NotFound();
            return Ok(programSetting);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProgramSetting programSetting)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _programSettingService.AddProgramSetting(programSetting);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] ProgramSetting newProgramSetting)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var programSetting = await _programSettingService.GetProgramSettingById(id);
            if (programSetting is null)
                return NotFound();
            newProgramSetting.Id = id;
            var result = await _programSettingService.UpdateProgramSetting(newProgramSetting);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var programSetting = await _programSettingService.GetProgramSettingById(id);
            if (programSetting is null)
                return NotFound();
            var result = await _programSettingService.DeleteProgramSetting(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
