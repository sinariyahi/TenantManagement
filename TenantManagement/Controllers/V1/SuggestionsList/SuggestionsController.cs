using Contracts.Dto.ServersList;
using Contracts.Dto.SuggestionsList;
using Contracts.Interface.TenantManagement.ServersList;
using Contracts.Interface.TenantManagement.SuggestionsList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.SuggestionsList
{
    [Route("api/Suggestions")]
    [ApiController]
    public class SuggestionsController : ControllerBase
    {
        private readonly ISuggestionsService _suggestionsService;
        public SuggestionsController(ISuggestionsService suggestionsService)
        {
            _suggestionsService = suggestionsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var suggestions = await _suggestionsService.GetSuggestions();
            return Ok(suggestions);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var suggestions = await _suggestionsService.GetSuggestionsById(id);
            if (suggestions is null)
                return NotFound();
            return Ok(suggestions);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Suggestions suggestions)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _suggestionsService.AddSuggestions(suggestions);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] Suggestions newSuggestions)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var suggestions = await _suggestionsService.GetSuggestionsById(id);
            if (suggestions is null)
                return NotFound();
            newSuggestions.Id = id;
            var result = await _suggestionsService.UpdateSuggestions(newSuggestions);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var suggestions = await _suggestionsService.GetSuggestionsById(id);
            if (suggestions is null)
                return NotFound();
            var result = await _suggestionsService.DeleteSuggestions(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
