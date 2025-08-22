using Appointments.Services;
using Microsoft.AspNetCore.Mvc;

namespace Appointments.Controllers;

[ApiController]
public class OptionsController(IOptionsService optionsService) : ControllerBase
{
   [HttpGet("api/options")] 
   public async Task<IActionResult> GetOptions()
   {
       var options = await optionsService.GetOptionsAsync();
       return Ok(options);
   }
}