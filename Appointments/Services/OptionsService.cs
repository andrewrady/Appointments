using Appointments.Models;
using Appointments.Representations;
using Microsoft.EntityFrameworkCore;
using NodaTime.TimeZones;

namespace Appointments.Services;

public class OptionsService : IOptionsService
{
    private ApplicationDbContext _context;
    
    public OptionsService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<OptionsResponse> GetOptionsAsync()
    {
       var eventTypes = await _context.EventTypes.ToListAsync();
       var usZones = TzdbDateTimeZoneSource.Default.ZoneLocations
           .Where(loc => loc.CountryCode == "US")
           .Select(loc => loc.ZoneId)
           .Distinct()
           .ToList();
       return new OptionsResponse { EventTypes = eventTypes, TimeZones = usZones}; 
    }
}