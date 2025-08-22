using Microsoft.EntityFrameworkCore;

namespace Appointments.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    DbSet<Event> Events { get; set; }
    public DbSet<EventType> EventTypes { get; set; }
}