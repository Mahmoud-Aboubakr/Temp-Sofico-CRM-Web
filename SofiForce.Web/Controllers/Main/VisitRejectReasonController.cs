using AutoMapper;
using DocumentFormat.OpenXml.Office2010.Excel;
using Helpers;
using Microsoft.AspNetCore.Mvc;
using SofiForce.BusinessObjects.Implementation;
using SofiForce.Models.Models.EntityModels;
using SofiForce.Web.Dapper.Implementation;
using SofiForce.Web.Dapper.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace SofiForce.Web.Controllers.Main;
[Route("api/[controller]")]
[ApiController]
public class VisitRejectReasonController : ControllerBase
{

    private readonly IVisitRejectReason _visitRejectReason;

    public VisitRejectReasonController(IVisitRejectReason visitRejectReason)
    {
        _visitRejectReason = visitRejectReason;
    }

    // GET: api/VisitRejectReason
    [CheckAuthorizedAttribute]
    [HttpGet]
    public async Task<IActionResult> GetAllVisitRejectReason()
    {
        return Ok(await _visitRejectReason.GetAllVisitRejectReasonASync());
    }

    // GET: api/VisitRejectReason/5
    [CheckAuthorizedAttribute]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetVisitRejectReasonById(int id)
    {
        var visitRejectReason = await _visitRejectReason.GetVisitRejectReasonByIdAsync(id);

        if (visitRejectReason == null)
        {
            return NotFound("Visit reject reason not found.");
        }

        return Ok(visitRejectReason);
    }

    // POST: api/VisitRejectReason
    [CheckAuthorizedAttribute]
    [HttpPost]
    public async Task<IActionResult> CreateVisitRejectReason([FromBody] VisitRejectReasonModel visitRejectReason)
    {
        var newId = await _visitRejectReason.CreateVisitRejectReasonAsync(visitRejectReason);
        return CreatedAtAction(nameof(GetVisitRejectReasonById), new { id = newId }, newId);
    }

    // PUT api/VisitRejectReason/5
    [CheckAuthorizedAttribute]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVisitRejectReasonAsync(int id, [FromBody] VisitRejectReasonModel visitRejectReason)
    {
        if (id != visitRejectReason.VisitRejectReasonId)
        {
            return BadRequest("Invalid request.");
        }

        var result = await _visitRejectReason.UpdateVisitRejectReasonAsync(visitRejectReason);

        if (result)
        {
            return NoContent();
        }

        return NotFound("Visit reject reason not found.");
    }

    // DELETE api/VisitRejectReason/5
    [CheckAuthorizedAttribute]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _visitRejectReason.DeleteVisitRejectReasonAsync(id);

        if (result)
        {
            return NoContent();
        }

        return NotFound("Visit reject reason not found.");
    }
}
