using Contracts.Dto.TefeEndeksList;
using Contracts.Dto.TenantsList;
using Contracts.Interface.TenantManagement.TefeEndeksList;
using Contracts.Interface.TenantManagement.TenantsList;
using Microsoft.AspNetCore.Mvc;

namespace TenantManagement.Controllers.V1.TenantsList
{
    [Route("api/Tenants")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantsService _tenantsService;
        public TenantsController(ITenantsService tenantsService)
        {
            _tenantsService = tenantsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tenants = await _tenantsService.GetTenants();
            return Ok(tenants);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var tenants = await _tenantsService.GetTenantsById(id);
            if (tenants is null)
                return NotFound();
            return Ok(tenants);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Tenants tenants)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _tenantsService.AddTenants(tenants);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] Tenants newTenants)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var tenants = await _tenantsService.GetTenantsById(id);
            if (tenants is null)
                return NotFound();
            newTenants.Id = id;
            var result = await _tenantsService.UpdateTenants(newTenants);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var tenants = await _tenantsService.GetTenantsById(id);
            if (tenants is null)
                return NotFound();
            var result = await _tenantsService.DeleteTenants(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
