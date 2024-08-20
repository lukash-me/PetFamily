using Microsoft.AspNetCore.Mvc;
using PetFamily.Application.Volunteers.CreateVolunteer;

namespace PetFamily.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VolunteerController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> CreateVolunteer(
        [FromServices] CreateVolunteerService service,
        [FromBody] CreateVolunteerRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await service.Handle(request, cancellationToken);
        if (result.IsFailure)
            return BadRequest(result.Error);
        
        return Ok(result.Value);
    }
}