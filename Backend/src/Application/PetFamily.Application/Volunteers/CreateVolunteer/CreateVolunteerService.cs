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

    public async Task<Result<Guid, Error>> Handle(CreateVolunteerRequest request, CancellationToken cancellationToken)
    {
        var volunteerId = VolunteerId.NewVolunteerId();

        var fullName = FullName.Create(
            request.FirstName,
            request.LastName,
            request.MiddleName).Value;

        var description = Description.Create(request.Description).Value;
        
        var phone = Phone.Create(request.Phone).Value;

        var socialNetworks = new SocialNetworks(
            request.SocialNetworks.Select(s =>
                    SocialNetwork.Create(s.link, s.title).Value).ToList());

        var requisites = new Requisites(
            request.Requisites.Select(s => 
                    Requisite.Create(s.title, s.description).Value).ToList());
        
        var experience = Experience.Create(request.Experience).Value;

        var housedCount = HousedCount.Create(request.HousedCount).Value;

        var searchingHouseCount = SearchingHouseCount.Create(request.SearchingHouseCount).Value;
        
        var treatmentCount = TreatmentCount.Create(request.TreatmentCount).Value;

        var volunteerResult = Volunteer.Create(
            volunteerId,
            fullName,
            description,
            phone,
            socialNetworks,
            requisites,
            experience,
            housedCount,
            searchingHouseCount,
            treatmentCount);
        
        if (volunteerResult.IsFailure)
            return volunteerResult.Error;

        await _volunteerRepository.Add(volunteerResult.Value);

        return volunteerResult.Value.Id.Value;
    }
}