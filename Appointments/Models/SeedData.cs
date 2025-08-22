namespace Appointments.Models;

public class SeedData
{
    public static void Initialize(ApplicationDbContext context)
    {
        if (context.EventTypes.Any())
            return;

        var eventTypes = new List<EventType>
        {
            new()
            {
                Type = "Office",
                IsActive = true,
                Durations = new List<int> { 30, 45, 60, 130 },
                ProductType = "Health"
            },
            new()
            {
                Type = "Home",
                IsActive = true,
                Durations = new List<int> { 30, 45, 60, 130 },
                ProductType = "Health"
            },
            new()
            {
                Type = "Phone",
                IsActive = true,
                Durations = new List<int> { 15, 30 },
                ProductType = "Health"
            }
        };

        context.EventTypes.AddRange(eventTypes);
        context.SaveChanges();
    }
}