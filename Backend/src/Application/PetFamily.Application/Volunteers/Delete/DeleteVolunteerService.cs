using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Shared;

namespace PetFamily.Application.Volunteers.Delete;

public class DeleteVolunteerService
{
    private readonly IVolunteerRepository _volunteerRepository;
    private readonly ILogger<DeleteVolunteerService> _logger;

    public DeleteVolunteerService(
        IVolunteerRepository volunteerRepository, 
        ILogger<DeleteVolunteerService> logger)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(
        DeleteVolunteerRequest request, 
        CancellationToken cancellationToken = default)
    {
        var volunteerResult = await _volunteerRepository.GetById(request.VolunteerId, cancellationToken);
        if (volunteerResult.IsFailure)
            return volunteerResult.Error;
        
        volunteerResult.Value.Delete();
        
        var result = await _volunteerRepository.Save(volunteerResult.Value, cancellationToken);
        
        _logger.LogInformation("Deleted volunteer with id {volunteerId}", result);

        return result;
    }
}