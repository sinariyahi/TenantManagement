using Contracts.Dto.SecurityLogsList;
using Contracts.Dto.SendMessagesList;
using Contracts.Interface.TenantManagement.SecurityLogsList;
using Contracts.Interface.TenantManagement.SendMessagesList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.SendMessagesList
{
    [Route("api/SendMessages")]
    [ApiController]
    public class SendMessagesController : ControllerBase
    {
        private readonly ISendMessagesService _sendMessagesService;
        public SendMessagesController(ISendMessagesService sendMessagesService)
        {
            _sendMessagesService = sendMessagesService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var sendMessages = await _sendMessagesService.GetSendMessages();
            return Ok(sendMessages);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var sendMessages = await _sendMessagesService.GetSendMessagesById(id);
            if (sendMessages is null)
                return NotFound();
            return Ok(sendMessages);
        }

        [HttpPost]
        public async Task<IActionResult> Post(SendMessages sendMessages)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _sendMessagesService.AddSendMessages(sendMessages);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] SendMessages newSendMessages)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var sendMessages = await _sendMessagesService.GetSendMessagesById(id);
            if (sendMessages is null)
                return NotFound();
            newSendMessages.Id = id;
            var result = await _sendMessagesService.UpdateSendMessages(newSendMessages);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var sendMessages = await _sendMessagesService.GetSendMessagesById(id);
            if (sendMessages is null)
                return NotFound();
            var result = await _sendMessagesService.DeleteSendMessages(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
