using CSharpFunctionalExtensions;
using Microsoft.Extensions.Logging;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers.AggregateRoot;
using PetFamily.Domain.Volunteers.IDs;
using PetFamily.Domain.Volunteers.ValueObjects;

namespace PetFamily.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerService
{
    private readonly IVolunteerRepository _volunteerRepository;
    private readonly ILogger<CreateVolunteerService> _logger;

    public CreateVolunteerService(
        IVolunteerRepository volunteerRepository, 
        ILogger<CreateVolunteerService> logger)
    {
        _volunteerRepository = volunteerRepository;
        _logger = logger;
    }

    public async Task<Result<Guid, Error>> Handle(CreateVolunteerRequest request, CancellationToken cancellationToken)
    {
        var volunteerId = VolunteerId.NewVolunteerId();

        var fullName = FullName.Create(
            request.FullName.FirstName,
            request.FullName.LastName,
            request.FullName.MiddleName).Value;

        var description = Description.Create(request.Description).Value;
        
        var phone = Phone.Create(request.Phone).Value;

        var socialNetworks = new SocialNetworks(
            request.SocialNetworks.Select(s =>
                    SocialNetwork.Create(s.link, s.title).Value).ToList());

        var requisites = new Requisites(
            request.Requisites.Select(s => 
                    Requisite.Create(s.title, s.description).Value).ToList());
        
        var experience = Experience.Create(request.Experience).Value;

        var volunteerResult = Volunteer.Create(
            volunteerId,
            fullName,
            description,
            phone,
            socialNetworks,
            requisites,
            experience);

        if (volunteerResult.IsFailure)
            return volunteerResult.Error;
        
        await _volunteerRepository.Add(volunteerResult.Value, cancellationToken);

        _logger.LogInformation("Created volunteer {fullname} with id {volunteerId}", fullName, volunteerId);
        
        return volunteerResult.Value.Id.Value;
    }
}