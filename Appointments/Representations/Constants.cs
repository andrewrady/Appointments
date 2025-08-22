using NodaTime.TimeZones;

namespace Appointments.Representations;

public static class Constants
{
    public static readonly List<string> UsZones = TzdbDateTimeZoneSource.Default.ZoneLocations
           .Where(loc => loc.CountryCode == "US")
           .Select(loc => loc.ZoneId)
           .Distinct()
           .ToList();
}