using Contracts.Dto.SuggestionsList;
using Contracts.Dto.TefeEndeksList;
using Contracts.Interface.TenantManagement.SuggestionsList;
using Contracts.Interface.TenantManagement.TefeEndeksList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.TefeEndeksList
{
    [Route("api/TefeEndeks")]
    [ApiController]
    public class TefeEndeksController : ControllerBase
    {
        private readonly ITefeEndeksService _tefeEndeksService;
        public TefeEndeksController(ITefeEndeksService tefeEndeksService)
        {
            _tefeEndeksService = tefeEndeksService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tefeEndeks = await _tefeEndeksService.GetTefeEndeks();
            return Ok(tefeEndeks);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var tefeEndeks = await _tefeEndeksService.GetTefeEndeksById(id);
            if (tefeEndeks is null)
                return NotFound();
            return Ok(tefeEndeks);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TefeEndeks tefeEndeks)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _tefeEndeksService.AddTefeEndeks(tefeEndeks);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        //[HttpPut("id")]
        //public async Task<IActionResult> Put(int id, [FromBody] TefeEndeks newTefeEndeks)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest("Invalid data");
        //    var tefeEndeks = await _tefeEndeksService.GetTefeEndeksById(id);
        //    if (tefeEndeks is null)
        //        return NotFound();
        //    newTefeEndeks.Id = id;
        //    var result = await _tefeEndeksService.UpdateTefeEndeks(newTefeEndeks);
        //    if (!result)
        //        return BadRequest("could not save data");
        //    return Ok();
        //}

        //[HttpDelete("id")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var tefeEndeks = await _tefeEndeksService.GetTefeEndeksById(id);
        //    if (tefeEndeks is null)
        //        return NotFound();
        //    var result = await _tefeEndeksService.DeleteTefeEndeks(id);
        //    if (!result)
        //        return BadRequest("could not save data");
        //    return Ok();
        //}

    }
}
