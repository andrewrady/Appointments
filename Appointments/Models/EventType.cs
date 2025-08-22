using System.ComponentModel.DataAnnotations;

namespace Appointments.Models;

public class EventType
{
    [Key] public int Id { get; set; }

    [Required]
    public string? Type { get; set; } // e.g., Call, Office, Home

    [Required]
    public string? ProductType { get; set; } // e.g., Health, Life

    [Required]
    public List<int>? Durations { get; set; } // e.g., [15, 30, 60]

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    
}