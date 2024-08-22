using Microsoft.AspNetCore.Mvc;
using PetFamily.API.Extensions;
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
            return result.Error.ToResponse();

        return CreatedAtAction("Post", result.Value);
    }

    public IActionResult Post()
    {
        throw new NotImplementedException();
    }
}