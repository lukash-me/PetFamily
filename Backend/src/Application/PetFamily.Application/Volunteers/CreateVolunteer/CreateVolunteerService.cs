using System.Runtime.InteropServices.JavaScript;
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

        var fullNameResult = FullName.Create(
            request.FirstName,
            request.LastName,
            request.MiddleName);
        if (fullNameResult.IsFailure)
            return Result.Failure<Guid>(fullNameResult.Error);

        var phoneResult = Phone.Create(request.Phone);
        if (phoneResult.IsFailure)
            return Result.Failure<Guid>(phoneResult.Error);

        var socialNetworksResult = request.SocialNetworks.Select(s =>
                SocialNetwork.Create(s.link, s.title))
            .ToList();
        if (socialNetworksResult.Any(r => r.IsFailure))
            return Result.Failure<Guid>(socialNetworksResult.FirstOrDefault(r => r.IsFailure)
                .Error);
        var socialNetworks = new SocialNetworks(socialNetworksResult.Select(s => s.Value)
            .ToList());

        var requisitesResult = request.Requisites.Select(s =>
                Requisite.Create(s.title, s.description))
            .ToList();
        if (requisitesResult.Any(r => r.IsFailure))
            return Result.Failure<Guid>(requisitesResult.FirstOrDefault(r => r.IsFailure)
                .Error);
        var requisites = new Requisites(requisitesResult.Select(s => s.Value)
            .ToList());

        var volunteerResult = Volunteer.Create(
            volunteerId,
            fullNameResult.Value,
            request.Description,
            phoneResult.Value,
            socialNetworks,
            requisites,
            request.Experience,
            request.HousedCount,
            request.SearchingHouseCount,
            request.TreatmentCount);
        
        if (volunteerResult.IsFailure)
            return Result.Failure<Guid>(volunteerResult.Error);

        await _volunteerRepository.Add(volunteerResult.Value);

        return volunteerResult.Value.Id.Value;
    }
}