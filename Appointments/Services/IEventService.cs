using Appointments.Models;
using Appointments.Representations;

namespace Appointments.Services;

public interface IEventService
{
    Task<IEnumerable<Event>> GetAllEventsAsync();
    Task<Event?> GetEventByIdAsync(int id);
    Task<Event> CreateEventAsync(EventCreateRequest request);
    Task<bool> UpdateEventAsync(int id, EventCreateRequest request);
    Task<bool> DeleteEventAsync(int id); 
}