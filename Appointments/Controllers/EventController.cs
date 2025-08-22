using Appointments.Representations;
using Appointments.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Controllers;

[ApiController]
[Authorize]
[Route("api/events")]
public class EventController(IEventService eventService) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var events = await eventService.GetAllEventsAsync();
        return Ok(events);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var evt = await eventService.GetEventByIdAsync(id);
        if (evt == null)
            return NotFound();
        return Ok(evt);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] EventCreateRequest request)
    {
        var created = await eventService.CreateEventAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] EventCreateRequest request)
    {
        var success = await eventService.UpdateEventAsync(id, request);
        if (!success)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var success = await eventService.DeleteEventAsync(id);
        if (!success)
            return NotFound();

        return NoContent();
    }
}