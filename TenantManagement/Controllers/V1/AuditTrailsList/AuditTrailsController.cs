using Contracts.Dto.AuditTrailsList;
using Contracts.Interface.TenantManagement.AuditTrailsList;
using Microsoft.AspNetCore.Mvc;
using System;

namespace TenantManagement.Controllers.V1.AuditTrailsList
{
    [Route("api/AuditTrails")]
    [ApiController]
    public class AuditTrailsController : ControllerBase
    {
        private readonly IAuditTrailsService _auditTrailsService;
        public AuditTrailsController(IAuditTrailsService auditTrailsService)
        {
            _auditTrailsService = auditTrailsService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var auditTrails = await _auditTrailsService.GetAuditTrails();
            return Ok(auditTrails);
        }

        [HttpGet("id")]
        public async Task<IActionResult> Get(int id)
        {
            var auditTrails = await _auditTrailsService.GetAuditTrailsById(id);
            if (auditTrails is null)
                return NotFound();
            return Ok(auditTrails);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AuditTrails auditTrails)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var result = await _auditTrailsService.AddAuditTrails(auditTrails);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpPut("id")]
        public async Task<IActionResult> Put(int id, [FromBody] AuditTrails newAuditTrails)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data");
            var auditTrails = await _auditTrailsService.GetAuditTrailsById(id);
            if (auditTrails is null)
                return NotFound();
            newAuditTrails.Id = id;
            var result = await _auditTrailsService.UpdateAuditTrails(newAuditTrails);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var auditTrails = await _auditTrailsService.GetAuditTrailsById(id);
            if (auditTrails is null)
                return NotFound();
            var result = await _auditTrailsService.DeleteAuditTrails(id);
            if (!result)
                return BadRequest("could not save data");
            return Ok();
        }

    }
}
