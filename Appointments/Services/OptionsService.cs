using Appointments.Models;
using Appointments.Representations;
using Microsoft.EntityFrameworkCore;

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
       
       return new OptionsResponse { EventTypes = eventTypes, TimeZones = Constants.UsZones }; 
    }
}