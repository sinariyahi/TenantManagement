using Contracts.Dto.SendMessagesList;
using Contracts.Dto.ServersList;
using Contracts.Interface.TenantManagement.SendMessagesList;
using Contracts.Interface.TenantManagement.ServersList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.ServersList
{
    [Route("api/Servers")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly IServersService _serversService;
        public ServersController(IServersService serversService)
        {
            _serversService = serversService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var servers = await _serversService.GetServers();
            return Ok(servers);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var servers = await _serversService.GetServersById(id);
            if (servers is null)
                return NotFound();
            return Ok(servers);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Servers servers)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _serversService.AddServers(servers);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] Servers newServers)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var servers = await _serversService.GetServersById(id);
            if (servers is null)
                return NotFound();
            newServers.Id = id;
            var result = await _serversService.UpdateServers(newServers);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var servers = await _serversService.GetServersById(id);
            if (servers is null)
                return NotFound();
            var result = await _serversService.DeleteServers(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
