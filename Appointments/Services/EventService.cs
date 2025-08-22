using System.Security.Claims;
using Appointments.Models;
using Appointments.Representations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Services;

public class EventService : IEventService
{
    private readonly ApplicationDbContext _context;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string? _userId;
    
    public EventService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;
        _userId = _httpContextAccessor.HttpContext?.User.Claims
            .LastOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _context.Events.Where(x => x.ApplicationUserId == _userId).ToListAsync();
    }

    public async Task<Event?> GetEventByIdAsync(int id)
    {
        return await _context.Events.FirstOrDefaultAsync(x => x.Id == id && x.ApplicationUserId == _userId);
    }

    public async Task<Event> CreateEventAsync(EventCreateRequest request)
    {
        var newEvent = new Event
        {
            Title = request.Title,
            Description = request.Description,
            StartTime = request.StartTime,
            EndTime = request.EndTime,
            TimeZone = request.TimeZone,
            Source = "Internal",
            Approved = true,
            ApplicationUserId = _userId
        };

        _context.Events.Add(newEvent);
        await _context.SaveChangesAsync();
        return newEvent;
    }

    public async Task<bool> UpdateEventAsync(int id, EventCreateRequest request)
    {
        
        var existingEvent = await _context.Events.FirstOrDefaultAsync(x => x.Id == id && x.ApplicationUserId == _userId);
        if (existingEvent == null)
            return false;

        existingEvent.Title = request.Title;
        existingEvent.Description = request.Description;
        existingEvent.StartTime = request.StartTime;
        existingEvent.EndTime = request.EndTime;
        existingEvent.TimeZone = request.TimeZone;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteEventAsync(int id)
    {
        var eventToDelete = await _context.Events.FirstOrDefaultAsync(x => x.Id == id && x.ApplicationUserId == _userId);
        if (eventToDelete == null)
            return false;

        _context.Events.Remove(eventToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}