using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Appointments.Models;

public class Event
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string ApplicationUserId { get; set; }

    [ForeignKey("ApplicationUserId")]
    public ApplicationUser ApplicationUser { get; set; }

    [Required]
    [MaxLength(255)]
    public string? Title { get; set; }

    public string? Description { get; set; }

    [Required]
    public DateTime StartTime { get; set; }

    [Required]
    public DateTime EndTime { get; set; }

    public bool Approved { get; set; }
    public string? TimeZone { get; set; }

    // Stores the Google Calendar event ID if applicable
    [MaxLength(255)]
    public string? GoogleEventId { get; set; }

    // Indicates if the event is internal or from Google
    [Required]
    [MaxLength(50)]
    public string? Source { get; set; } 
}