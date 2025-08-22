using System.Security.Claims;
using Appointments.Models;
using Appointments.Representations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Appointments.Services;

public class EventService : IEventService
{
    private readonly ApplicationDbContext _context;
    private string userId;
    
    public EventService(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        userId = userManager.GetUserId(httpContextAccessor.HttpContext.User);
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync()
    {
        return await _context.Events.Where(x => x.ApplicationUserId == userId).ToListAsync();
    }

    public async Task<Event?> GetEventByIdAsync(int id)
    {
        return await _context.Events.FindAsync(id);
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
            ApplicationUserId = userId
            //ApplicationUserId = "d7d9700c-f5dd-495c-b427-0563bc76b8c9"
        };

        _context.Events.Add(newEvent);
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