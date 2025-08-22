using Appointments.Models;

namespace Appointments.Representations;

public class OptionsResponse
{
    public IEnumerable<EventType> EventTypes { get; set; }
}