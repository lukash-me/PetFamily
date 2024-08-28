using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.ValueObjects;

namespace PetFamily.Application.Volunteers.UpdateRequisites;

public class UpdateRequisitesService
{
    private readonly IVolunteerRepository _volunteerRepository;
    private readonly ILogger<UpdateRequisitesService> _logger;

    public UpdateRequisitesService(IVolunteerRepository volunteerRepository, ILogger<UpdateRequisitesService> logger)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(
        UpdateRequisitesRequest request, 
        CancellationToken cancellationToken = default)
    {
        var volunteer = await _volunteerRepository.GetById(request.VolunteerId, cancellationToken);
        if (volunteer.IsFailure)
            return volunteer.Error;

        var requisites = new Requisites(
            request.Requisites.Select(s => 
                Requisite.Create(s.title, s.description).Value).ToList());
        
        volunteer.Value.UpdateRequisites(requisites);

        await _volunteerRepository.Save(volunteer.Value, cancellationToken);
        _logger.LogInformation(
            "Updated volunteers requisites {requisites} with id {volunteerId}",
            requisites.Requisite,
            request.VolunteerId);

        return request.VolunteerId;
    }
}