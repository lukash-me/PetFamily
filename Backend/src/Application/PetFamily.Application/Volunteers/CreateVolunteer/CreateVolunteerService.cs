using CSharpFunctionalExtensions;
using PetFamily.Domain.Shared;
using PetFamily.Domain.Volunteers;

namespace PetFamily.Application.Volunteers.CreateVolunteer;

public class CreateVolunteerService
{
    private readonly IVolunteerRepository _volunteerRepository;

    public CreateVolunteerService(IVolunteerRepository volunteerRepository)
    {
        _volunteerRepository = volunteerRepository;
    }

    public async Task<Result<Guid>> Handle(CreateVolunteerRequest request, CancellationToken cancellationToken)
    {
        var volunteerId = VolunteerId.NewVolunteerId();

        var fullNameResult = FullName.Create(request.firstName, request.lastName, request.middleName);
        if (fullNameResult.IsFailure)
            return Result.Failure<Guid>(fullNameResult.Error);

        var phoneResult = Phone.Create(request.phone);
        if (phoneResult.IsFailure)
            return Result.Failure<Guid>(phoneResult.Error);
        
        var socialNetworksList = request.socialNetworks.Select(s =>
            new SocialNetwork(s.link, s.title)).ToList();
        var socialNetworks = new SocialNetworks(socialNetworksList);
        
        var requisitesList = request.requisites.Select(r =>
            new Requisite(r.title, r.description)).ToList();
        var requisites = new Requisites(requisitesList);
        
        var volunteerResult = Volunteer.Create(volunteerId, fullNameResult.Value, request.description,
            phoneResult.Value, socialNetworks, requisites, request.experience, request.housedCount,
            request.searchingHouseCount, request.treatmentCount);
        if (volunteerResult.IsFailure)
            return Result.Failure<Guid>(volunteerResult.Error);

        await _volunteerRepository.Add(volunteerResult.Value);

        return volunteerResult.Value.Id.Value;
    }
}