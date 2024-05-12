using Contracts.Dto.PublicHolidaysList;
using Contracts.Interface.TenantManagement.PublicHolidaysList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.PublicHolidaysList
{
    [Route("api/PublicHolidays")]
    [ApiController]
    public class PublicHolidaysController : ControllerBase
    {
        private readonly IPublicHolidaysService _publicHolidaysService;
        public PublicHolidaysController(IPublicHolidaysService publicHolidaysService)
        {
            _publicHolidaysService = publicHolidaysService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var publicHolidays = await _publicHolidaysService.GetPublicHolidays();
            return Ok(publicHolidays);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var publicHolidays = await _publicHolidaysService.GetPublicHolidaysById(id);
            if (publicHolidays is null)
                return NotFound();
            return Ok(publicHolidays);
        }

        [HttpPost]
        public async Task<IActionResult> Post(PublicHolidays publicHolidays)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _publicHolidaysService.AddPublicHolidays(publicHolidays);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] PublicHolidays newPublicHolidays)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var publicHolidays = await _publicHolidaysService.GetPublicHolidaysById(id);
            if (publicHolidays is null)
                return NotFound();
            newPublicHolidays.Id = id;
            var result = await _publicHolidaysService.UpdatePublicHolidays(newPublicHolidays);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var publicHolidays = await _publicHolidaysService.GetPublicHolidaysById(id);
            if (publicHolidays is null)
                return NotFound();
            var result = await _publicHolidaysService.DeletePublicHolidays(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
