using Appointments.Representations;

namespace Appointments.Services;

public interface IOptionsService
{
    Task<OptionsResponse> GetOptionsAsync();
}