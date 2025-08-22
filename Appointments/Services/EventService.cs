using Appointments.Models;
using Appointments.Representations;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Services;

public class EventService : IEventService
{
    private readonly ApplicationDbContext _context;

    public EventService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _context.Set<Event>().ToListAsync();
    }

    public async Task<Event?> GetEventByIdAsync(int id)
    {
        return await _context.Set<Event>().FindAsync(id);
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
            Approved = true
        };

        _context.Set<Event>().Add(newEvent);
        await _context.SaveChangesAsync();
        return newEvent;
    }

    public async Task<bool> UpdateEventAsync(int id, EventCreateRequest request)
    {
        
        var existingEvent = await _context.Set<Event>().FindAsync(id);
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
        var eventToDelete = await _context.Set<Event>().FindAsync(id);
        if (eventToDelete == null)
            return false;

        _context.Set<Event>().Remove(eventToDelete);
        await _context.SaveChangesAsync();
        return true;
    }
}